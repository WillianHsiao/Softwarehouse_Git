using Business.Services;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Softwarehouse.ViewModels;
using System.Web.Http;

namespace Softwarehouse.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginApiController : ApiController
    {
        [HttpPost]
        [Route("MemberLogin")]
        public MemberLoginServiceResult Login([FromBody]LoginViewModel model)
        {
            MemberLoginServiceResult result;
            MemberLoginService service = new MemberLoginService
            {
                Resources = new MemberLoginServiceCondition
                {
                    Account = model.Account,
                    Password = model.Password
                }
            };
            if (service.Check())
            {
                result = service.Work();
            }
            else
            {
                result = new MemberLoginServiceResult()
                {
                    Result = service.State,
                    ErrorMessage = service.StateMessage
                };
            }
            return result;
        }
    }
}
