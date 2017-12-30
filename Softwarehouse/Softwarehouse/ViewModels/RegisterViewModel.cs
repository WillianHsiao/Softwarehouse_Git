using System.ComponentModel.DataAnnotations;

namespace Softwarehouse.ViewModels
{
    /// <summary>
    /// 註冊
    /// </summary>
    public class RegisterViewModel
    {
        [Display(Name = "姓名"), Required]
        public string Name { get; set; }
        [Display(Name = "帳號"), Required(ErrorMessage ="請輸入帳號")]
        public string Account { get; set; }
        [Display(Name = "Email"), Required(ErrorMessage = "請輸入Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "密碼"), Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "確認密碼"), Required(ErrorMessage = "請確認密碼")]
        [Compare(nameof(Password), ErrorMessage = "與輸入的密碼不符合")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}