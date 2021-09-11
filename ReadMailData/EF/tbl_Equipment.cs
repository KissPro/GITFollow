namespace ReadMailData.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Equipment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string idRequests { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Partcode { get; set; }

        public int? QuantityNumber { get; set; }

        [StringLength(50)]
        public string QuantityWord { get; set; }

        [StringLength(150)]
        public string Remark { get; set; }

        public virtual tbl_Requests tbl_Requests { get; set; }
    }
}
