namespace Business.Models.SoftwarehouseDB
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class SoftwarehouseDBModel : DbContext
    {
        /// <summary>
        /// 建立所有預存程序的集合主體
        /// </summary>
        public virtual Procedure GenerateProcedure { get; set; }
        /// <summary>
        /// 預存程序的集合主體
        /// </summary>
        public class Procedure
        {
            private SoftwarehouseDBModel softwarehouseDBModel;
            /// <summary>
            /// 預存程序的集合主體
            /// </summary>
            /// <param name="cManDanModel"></param>
            public Procedure(SoftwarehouseDBModel softwarehouseDBModel)
            {
                // TODO: Complete member initialization
                this.softwarehouseDBModel = softwarehouseDBModel;

                // TODO Add your SPs to init
                //this.USP_ChangeOrgTimeAlertByPerson = new SpValueSet<USP_ChangeOrgTimeAlertByPerson>(this.cManDanModel);
            }
        }
    }
}
