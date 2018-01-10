using Common.Helpers;
using ObjectCollection.ServiceResults;
using Softwarehouse.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace Softwarehouse.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        public ActionResult Index(string returnUrl)
        {
            if (SiteHelper.IsLogin())
            {
                return RedirectToLocal(returnUrl);
            }
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            LoginApiController controller = new LoginApiController();
            MemberLoginServiceResult result = controller.Login(model);
            if (!result.Result)
            {
                return RedirectToLocal(model.ReturnUrl);
            }

            return View();
        }

        public ActionResult SignOut()
        {
            Session.RemoveAll();

            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}