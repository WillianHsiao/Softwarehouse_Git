using System.ComponentModel.DataAnnotations;

namespace Softwarehouse.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "姓名"), Required]
        public string Name { get; set; }
        [Display(Name = "帳號"), Required]
        public string Account { get; set; }
        [Display(Name = "密碼"), Required]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        [Compare(nameof(Password), ErrorMessage = "與輸入的密碼不符合")]
        public string ConfirmPassword { get; set; }
    }
}