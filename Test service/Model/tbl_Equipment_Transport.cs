using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_service.Model
{
    public class tbl_Equipment_Transport
    {
        public int Id { get; set; }

        [Required]
        public string ObjectJson { get; set; }

        [Required]
        public string ImagesBase64 { get; set; }

        [Required]
        [StringLength(10)]
        public string CreateDate { get; set; }

        public bool Status { get; set; }
    }
}
