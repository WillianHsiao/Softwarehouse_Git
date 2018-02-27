using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models.SoftwarehouseDB
{
    [Table("MemberResetPassword")]
    public class MemberResetPassword
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("MemberAccount")]
        public string MemberAccount { get; set; }

        [Column("UniqueKey")]
        public string UniqueKey { get; set; }

        [Column("SaltString")]
        public string SaltString { get; set; }
    }
}
