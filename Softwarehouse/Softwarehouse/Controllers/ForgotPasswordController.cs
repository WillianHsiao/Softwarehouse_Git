using ObjectCollection.ServiceResults;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Softwarehouse.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CheckEmailAddress(string Email)
        {
            return Json(new RegisterApiController().MemberEmailRepeat(Email).IsRepeat,
                JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SendResetPasswordEmail(string Email)
        {
            ForgotPasswordApiController controller = new ForgotPasswordApiController();
            MemberSendResetPasswordEmailServiceResult result = await controller.SendResetPasswordEmail(Email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ResetPassword(string UniqueKey)
        {
            return View();
        }
    }
}