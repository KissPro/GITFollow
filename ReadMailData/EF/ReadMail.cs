namespace ReadMailData.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReadMail : DbContext
    {
        public ReadMail()
            : base("name=ReadMail2")
        {
        }

        public virtual DbSet<tbl_Equipment> tbl_Equipment { get; set; }
        public virtual DbSet<tbl_Requester> tbl_Requester { get; set; }
        public virtual DbSet<tbl_Requests> tbl_Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Equipment>()
                .Property(e => e.idRequests)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Equipment>()
                .Property(e => e.Partcode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Requester>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Requester>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Requester>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Requester>()
                .HasMany(e => e.tbl_Requests)
                .WithRequired(e => e.tbl_Requester)
                .HasForeignKey(e => e.idRequester);

            modelBuilder.Entity<tbl_Requests>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Requests>()
                .HasMany(e => e.tbl_Equipment)
                .WithRequired(e => e.tbl_Requests)
                .HasForeignKey(e => e.idRequests)
                .WillCascadeOnDelete(false);
        }
    }
}
