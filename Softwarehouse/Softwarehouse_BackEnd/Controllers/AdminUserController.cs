using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Repositories;

namespace Softwarehouse_BackEnd.Controllers
{
    public class AdminUserController : Controller
    {
        private AdminUsersRepository _repository;

        public AdminUserController(AdminUsersRepository repository)
        {
            _repository = repository;
        }

        // GET: User
        public ActionResult Index()
        {
            var t = _repository.Get(1);
            return View();
        }
    }
}