using System.Data.Entity;

namespace Business.Models.SoftwarehouseDB
{
    public partial class SoftwarehouseDBModel : DbContext
    {
        public SoftwarehouseDBModel()
            : base("name=SoftwarehouseDB")
        {
            this.GenerateProcedure = new Procedure(this);
        }

        /// <summary>
        /// AdminUsers
        /// </summary>
        public virtual DbSet<AdminUsers> AdminUsers { get; set; }
        /// <summary>
        /// VipUsers
        /// </summary>
        public virtual DbSet<VipUsers> VipUsers { get; set; }
        /// <summary>
        /// Members
        /// </summary>
        public virtual DbSet<Members> Members { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
