using Business.Models.SoftwarehouseDB;
using Business.Repositories;
using ObjectCollection.RepositoryConditions;
using Softwarehouse.ViewModels;
using System.Linq;
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
        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var bResult = false;
            if(TryUpdateModel(model) && ModelState.IsValid)
            {
                _repository.Create(new Members
                {
                    Account = model.Account,
                    Password = model.Password,
                    Email = model.Email
                });
                ViewBag.Success = bResult = _repository.State;
            }
            return View("Index", model);
        }
        /// <summary>
        /// 檢查帳號是否重複
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckAccountIsRepeated(string account)
        {
            var isRepeated = _repository.Read(new MembersRepoCondition
            {
                Account = account
            }).Any();
            return Content(isRepeated.ToString());
        }
    }
}