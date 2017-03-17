using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.SoftwarehouseDB
{
    [Table("VipData")]
    public class VipData
    {
        public VipData()
        {

        }
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserAccountId")]
        public int UserAccountId { get; set; }

        [ForeignKey(nameof(UserAccountId))]
        public UserAccount UserAccount { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("IsDelete")]
        public bool IsDelete { get; set; }

        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column("UpdateDate")]
        public DateTime UpdateDate { get; set; }
    }
}
