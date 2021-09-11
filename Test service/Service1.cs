using Microsoft.Exchange.WebServices.Data;
using Newtonsoft.Json;
using ReadMailData.Dao;
using ReadMailData.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Test_service.Helper;
using Test_service.Mail;
using Test_service.Model;
using System.Configuration;
using System.Net.Http;
using System.Net;

namespace Test_service
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer = null;
        protected static string pathDefaultImages = ConfigurationManager.AppSettings["pathDefaultImages"];

        protected static string userCredential = ConfigurationManager.AppSettings["userCredential"];
        protected static string passCredential = ConfigurationManager.AppSettings["passCredential"];

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Tạo 1 timer từ libary System.Timesrs
            timer = new Timer();
            // Execute mỗi 2p
            timer.Interval = 120000;
            // Những gì xảy ra khi timer đó dc tick
            timer.Elapsed += timer_Tick;
            // Enable timer
            timer.Enabled = true;
            // Ghi vào log file khi services dc start lần đầu tiên
            WriteLogError.Write("Start================");

        }
        private void timer_Tick(object sender, ElapsedEventArgs args)
        {
            try
            {
                // List request
                List<NewRequestJsonModel> listRequests = new List<NewRequestJsonModel>();
                var helper = new APIHelper();
                HttpResponseMessage response = helper.HttpClient.GetAsync("index").Result;
                var requestsList = JsonConvert.DeserializeObject<List<tbl_Equipment_Transport>>(response.Content.ReadAsStringAsync().Result);
                foreach (var request in requestsList)
                {
                    // Get body
                    NewRequestJsonModel newRequests = JsonConvert.DeserializeObject<NewRequestJsonModel>(request.ObjectJson);
                    // Get image - Store image
                    List<ImagesJsonBase64> listImages = JsonConvert.DeserializeObject<List<ImagesJsonBase64>>(request.ImagesBase64);
                    // Create new folder 
                    string pathImages = Path.Combine(pathDefaultImages, newRequests.request.id.Trim());
                    System.IO.Directory.CreateDirectory(pathImages);
                    // Save file to new folder
                    foreach (var item in listImages)
                    {
                        GetImages(item.imagesBase64, pathImages + @"\" + item.name);
                    }
                    listRequests.Add(newRequests);
                }
                // Delete request - list images
                helper.HttpClient.GetAsync("delete");
                // Fill to database
                if (listRequests != null && listRequests.Count != 0)
                {
                    InsertToDatabase(listRequests);
                }
            }
            catch (Exception e)
            {
                WriteLogError.Write("Error: " + DateTime.Now.ToString() + "-" + e.ToString());
            }
        }
        protected override void OnStop()
        {
            // Ghi log lại khi Services đã được stop
            timer.Enabled = true;
        }

        public bool GetImages(string pathImage, string pathStore)
        {
            try
            {
                var helper = new APIHelper();
                WebClient request = new WebClient();
                request.Proxy = new WebProxy(helper.proxy, true);
                request.Proxy.Credentials = new NetworkCredential("V1517299", "Saodoingoi!2", "FUSHAN");
                request.DownloadFile(pathImage, pathStore);
                return true;
            }
            catch (Exception e)
            {
                WriteLogError.Write("Error: " + DateTime.Now.ToString() + "-" + e.ToString());
                return false;
            }
        }
        public bool DeleteImages(string pathImage)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(pathImage);
                request.Credentials = new NetworkCredential(userCredential, passCredential);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Proxy = null;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    var result = response.StatusDescription;
                }
                return true;
            }
            catch (Exception e)
            {
                WriteLogError.Write("Error: " + DateTime.Now.ToString() + "-" + e.ToString());
                return false;
            }
        }
        public void InsertToDatabase(List<NewRequestJsonModel> listRq)
        {
            try
            {
                var requesterDao = new RequesterDao();
                var requestsDao = new RequestsDao();
                var equipmentDao = new EquipmentDao();

                List<NewRequestJsonModel> listRequests = listRq;
                foreach (var item in listRequests)
                {
                    // add requester infor
                    var requester = new tbl_Requester();
                    requester.Name = item.requester.Name;
                    requester.PhoneNumber = item.requester.PhoneNumber;
                    requester.Email = (item.requester.Email != "") ? item.requester.Email : "hoangturom9x@gmail.com";
                    requester.Company = item.requester.Company;
                    requester.Address = item.requester.Address;
                    requester.HostName = item.requester.HostName;
                    requester.Department = item.requester.Department;
                    var idRequester = requesterDao.InsertRequester(requester);

                    // add requests infor
                    var requests = new tbl_Requests();
                    requests.id = item.request.id;
                    requests.idRequester = idRequester;
                    requests.incommingDate = item.request.incommingDate;
                    requests.outgoingDate = item.request.outgoingDate;
                    requests.createDate = DateTime.Now;
                    var idRequests = requestsDao.InsertRequests(requests);

                    // add goods description

                    List<EquipmentJsonModel> listEquipment = item.equipment;
                    if (listEquipment != null)
                    {
                        foreach (var equip in listEquipment)
                        {
                            var equipment = new tbl_Equipment();
                            equipment.id = equip.id;
                            equipment.idRequests = idRequests;
                            equipment.Name = equip.Name;
                            equipment.Partcode = equip.Partcode;
                            equipment.QuantityNumber = Convert.ToInt32(equip.QuantityNumber);
                            equipment.QuantityWord = equip.QuantityWord;
                            equipment.Remark = equip.Remark;
                            var idEquipment = equipmentDao.InsertEquipment(equipment);
                        }
                    }
                    WriteLogError.Write("Success: Save to database " + requests.id + " - " + DateTime.Now.ToString());
                    // Send mail when insert database success
                    var sendMail = new SendMail();
                    var result = sendMail.SendMailSuccess(item.requester.Email.Trim(), item.requester.Name.Trim(), item.request.id);
                    if (result == "Success")
                    {
                        WriteLogError.Write("Success: Send mail oke -" + DateTime.Now.ToString());
                    }
                    else
                    {
                        WriteLogError.Write("Error: Send mail false -" + DateTime.Now.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                WriteLogError.Write("Error: " + DateTime.Now.ToString() + "-" + e.ToString());
            }

        }
    }
}
