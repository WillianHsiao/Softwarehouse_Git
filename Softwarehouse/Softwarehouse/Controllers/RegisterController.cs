using Business.Repositories;
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
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
    }
}