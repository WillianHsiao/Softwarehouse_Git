using System.ComponentModel.DataAnnotations;

namespace Softwarehouse.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "帳號")]
        public string MemberAccount { get; set; }
        public string UniqueKey { get; set; }
        [Display(Name = ("新密碼"))]
        public string NewPassword { get; set; }
        [Display(Name = ("確認新密碼"))]
        public string ConfirmNewPassword { get; set; }
    }
}