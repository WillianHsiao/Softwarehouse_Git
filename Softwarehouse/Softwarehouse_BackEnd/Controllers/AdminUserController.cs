using System.Web.Mvc;
using Business.Repositories;
using ObjectCollection.RepositoryConditions;

namespace Softwarehouse_BackEnd.Controllers
{
    public class AdminUserController : Controller
    {
        private AdminUsersRepository _repository;

        public AdminUserController(AdminUsersRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(AdminUsersRepoCondition condition)
        {
            var adminUsers = _repository.Read(condition);
            return View(adminUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection fc)
        {
            return View();
        }

        public ActionResult Delete(int)
        {
            return View();
        }
    }
}