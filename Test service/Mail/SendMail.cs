using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Test_service.Mail
{
    public class SendMail
    {
        SmtpClient client = null;
        string mailServer = string.Empty;
        string mailPort = string.Empty;
        //string email = string.Empty;
        //string pw = string.Empty;
        public SendMail()
        {
            client = new SmtpClient();
            try
            {
                mailServer = "10.57.48.53";
                mailPort = "25";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            int port;
            int.TryParse(mailPort, out port);
            try
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;
                client.Host = mailServer;
                client.Port = port != 0 ? port : 25;
            }
            catch (Exception ex)
            {
            }
        }
        private void Send(string mailTo, List<string> mailCC, string subject, string content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                //for (int i = 0; i < mailTo.Count; i++)

                if (mailCC != null && mailCC.Count > 0)
                {
                    foreach (var item in mailCC)
                        mail.CC.Add(item);
                }
                mail.To.Add(mailTo);
                mail.From = new MailAddress("no-reply@fih-foxconn.com");
                mail.Subject = subject;
                mail.Body = content;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;
                client.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }

        // Send mail success

        public string SendMailSuccess(string mailTo, string name, string id)
        {
            try
            {
                string subject = "[FIH ProfomaInvoice] Register Success";
                string content = string.Format(MailTemplate.Email_Confirm_Success, name, id);
                Send(mailTo, null, subject, content);
                return "Success";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
