namespace ReadMailData.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Requests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Requests()
        {
            tbl_Equipment = new HashSet<tbl_Equipment>();
        }

        [StringLength(20)]
        public string id { get; set; }

        public int idRequester { get; set; }

        public DateTime incommingDate { get; set; }

        public DateTime outgoingDate { get; set; }

        public DateTime createDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Equipment> tbl_Equipment { get; set; }

        public virtual tbl_Requester tbl_Requester { get; set; }
    }
}
