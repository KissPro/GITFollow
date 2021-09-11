using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_service
{
    public class RequesterModel
    {
        public string RequestID { get; set; }
        public string requested { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string Email { get; set; }

        public string HostName { get; set; }
        public string Department { get; set; }

        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public List<GoodsModel> goods { get; set; }
        public string[] listImages { get; set; }
    }
}
