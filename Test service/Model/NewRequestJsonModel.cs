using ReadMailData.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_service.Model
{
    public class NewRequestJsonModel
    {
        public NewRequestJsonModel()
        {
            request = new tbl_Requests();
            requester = new tbl_Requester();
        }
        public tbl_Requests request { set; get; }
        public tbl_Requester requester { set; get; }
        public List<EquipmentJsonModel> equipment { set; get; }
    }
    public class EquipmentJsonModel
    {
        public int id { get; set; }
        public string idRequests { get; set; }
        public string Name { get; set; }
        public string Partcode { get; set; }
        public int? QuantityNumber { get; set; }
        public string QuantityWord { get; set; }
        public string Remark { get; set; }
    }

}
