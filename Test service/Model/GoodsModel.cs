using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_service
{
    public class GoodsModel
    {
        public GoodsModel() { }
        public int Id { set; get; }
        public string Name { set; get; }
        public string Partcode { set; get; }
        public string QuantityNumber { set; get; }
        public string QuantityWord { set; get; }
        public string Remark { set; get; }
    }
}
