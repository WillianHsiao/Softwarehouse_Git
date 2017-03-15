using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.SoftwarehouseDB
{
    [Table("Member")]
    public partial class Member
    {
        public Member()
        {

        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Account")]
        public string Account { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("IsDelete")]
        public bool IsDelete { get; set; }

        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column("UpdateDate")]
        public DateTime UpdateDate { get; set; }
    }
}
