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
        /// 後台管理者
        /// </summary>
        public virtual DbSet<AdminUsers> AdminUsers { get; set; }
        /// <summary>
        /// 付費會員
        /// </summary>
        public virtual DbSet<VipUsers> VipUsers { get; set; }
        /// <summary>
        /// 會員
        /// </summary>
        public virtual DbSet<Members> Members { get; set; }

        /// <summary>
        /// 重設密碼清單
        /// </summary>
        public virtual DbSet<MemberResetPassword> MemberResetPassword { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
