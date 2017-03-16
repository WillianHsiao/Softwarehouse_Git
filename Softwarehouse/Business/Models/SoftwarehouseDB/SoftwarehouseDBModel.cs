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
        /// ManagerInfo
        /// </summary>
        public virtual DbSet<Member> Member { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
