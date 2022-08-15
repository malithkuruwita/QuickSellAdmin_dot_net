namespace QuickSellAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuickSellData : DbContext
    {
        public QuickSellData()
            : base("name=QuickSellData")
        {
        }

        public virtual DbSet<addDetail> addDetails { get; set; }
        public virtual DbSet<adminAccount> adminAccounts { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<savedAdd> savedAdds { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<userAccount> userAccounts { get; set; }
        public virtual DbSet<vipDetail> vipDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
