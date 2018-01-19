using System.ComponentModel.DataAnnotations;

namespace Softwarehouse.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "帳號")]
        public string Account { get; set; }
        [Display(Name = "密碼")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}