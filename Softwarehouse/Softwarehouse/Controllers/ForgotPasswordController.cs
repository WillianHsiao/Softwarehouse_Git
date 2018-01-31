using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult ResetPassword(string Email)
        {
            return View("Index", "ForgotPassword");
        }
    }
}