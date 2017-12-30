using Business.Services;
using ObjectCollection.ServiceConditions;
using Softwarehouse.ViewModels;
using System.Web.Mvc;

namespace Softwarehouse.Controllers
{
    /// <summary>
    /// 註冊會員Controller
    /// </summary>
    public class RegisterController : Controller
    {
        [AllowAnonymous]
        // GET: Register
        public ActionResult Index()
        {
            var model = new RegisterViewModel();

            return View(model);
        }
    }
}