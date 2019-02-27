using Business.Services;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Softwarehouse.ViewModels;
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
        public ActionResult ResetPassword(string MemberAccount, string UniqueKey)
        {
            MemberCheckResetPasswordUrlServiceResult result;
            MemberCheckResetPasswordUrlService service = new MemberCheckResetPasswordUrlService
            {
                Resources = new MemberCheckResetPasswordUrlServiceCondition
                {
                    MemberAccount = MemberAccount,
                    UniqueKey = UniqueKey
                }
            };
            if (service.Check())
            {
                result = service.Work();
            }
            else
            {
                result = new MemberCheckResetPasswordUrlServiceResult()
                {
                    Result = service.State,
                    ErrorMessage = service.StateMessage
                };
            }
            if (result.Result)
            {
                ResetPasswordViewModel model = new ResetPasswordViewModel
                {
                    MemberAccount = MemberAccount,
                    UniqueKey = UniqueKey
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult ConfirmResetPassword(ResetPasswordViewModel model)
        {
            MemberResetPasswordServiceResult result;
            MemberResetPasswordService service = new MemberResetPasswordService
            {
                Resources = new MemberResetPasswordServiceCondition
                {
                    MemberAccount = model.MemberAccount,
                    NewPassword = model.NewPassword
                }
            };
            if (service.Check())
            {
                result = service.Work();
            }
            else
            {
                result = new MemberResetPasswordServiceResult
                {
                    Result = service.State,
                    ErrorMessage = service.StateMessage
                };
            }
            return Json(result);
        }
    }
}