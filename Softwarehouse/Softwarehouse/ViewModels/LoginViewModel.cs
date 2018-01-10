using System.ComponentModel.DataAnnotations;

namespace Softwarehouse.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Account { get; set; }
        [DataType(DataType.Password),Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}