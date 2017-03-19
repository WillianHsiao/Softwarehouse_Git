using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models.SoftwarehouseDB
{
    [Table("AdminUsers")]
    public class AdminUser
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Account")]
        public string Account { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Email")]
        public string Email { get; set; }
    }
}
