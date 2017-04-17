using Business.Repositories;
using Softwarehouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softwarehouse.Controllers
{
    /// <summary>
    /// 註冊會員Controller
    /// </summary>
    public class RegisterController : Controller
    {
        private MembersRepository _repository;

        public RegisterController(MembersRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        // GET: Register
        public ActionResult Index()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        public ActionResult Register(RegisterViewModel model)
        {
            return Content("");
        }
    }
}