using Softwarehouse.ViewModels;
using System.Web.Mvc;

namespace Softwarehouse.Controllers
{
    /// <summary>
    /// 註冊會員Controller
    /// </summary>
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            var model = new RegisterViewModel();

            return View(model);
        }
        public JsonResult MemberAccountRepeat(string Account)
        {
            return Json(!new RegisterApiController().MemberAccountRepeat(Account).IsRepeat, 
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult MemberEmailRepeat(string Email)
        {
            return Json(!new RegisterApiController().MemberEmailRepeat(Email).IsRepeat, 
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrivacyPolicy()
        {
            return PartialView();
        }
    }
}