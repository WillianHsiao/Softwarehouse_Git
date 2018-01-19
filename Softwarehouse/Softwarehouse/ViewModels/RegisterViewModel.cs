using System.ComponentModel.DataAnnotations;

namespace Softwarehouse.ViewModels
{
    /// <summary>
    /// 註冊
    /// </summary>
    public class RegisterViewModel
    {
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "帳號")]
        public string Account { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "確認密碼")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}