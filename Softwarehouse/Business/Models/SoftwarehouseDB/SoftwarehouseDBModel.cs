using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
