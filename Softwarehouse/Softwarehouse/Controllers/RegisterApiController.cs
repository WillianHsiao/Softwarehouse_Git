using Business.Services;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Softwarehouse.ViewModels;
using System.Web.Http;

namespace Softwarehouse.Controllers
{
    [RoutePrefix("api/register")]
    public class RegisterApiController : ApiController
    {
        [HttpPost]
        [Route("MemberRegister")]
        public CreateMemberServiceResult MemberRegister([FromBody]RegisterViewModel model)
        {
            CreateMemberServiceResult result;
            CreateMemberService service = new CreateMemberService
            {
                Resources = new CreateMemberServiceCondition
                {
                    Account = model.Account,
                    Password = model.Password,
                    Email = model.Email
                }
            };
            if (service.Check())
            {
                result = service.Work();
            }
            else
            {
                result = new CreateMemberServiceResult
                {
                    Result = service.State,
                    ErrorMessage = service.StateMessage
                };
            }
            return result;
        }
        [HttpGet]
        [Route("MemberAccountRepeat")]
        public MemberAccountRepeatServiceResult MemberAccountRepeat(string Account)
        {
            MemberAccountRepeatServiceResult result;
            MemberAccountRepeatService service = new MemberAccountRepeatService
            {
                Resources = new MemberAccountRepeatServiceCondition
                {
                    Account = Account,
                }
            };
            if (service.Check())
            {
                result = service.Work();
            }
            else
            {
                result = new MemberAccountRepeatServiceResult()
                {
                    Result = service.State,
                    ErrorMessage = service.StateMessage
                };
            }
            return result;
        }
        [HttpGet]
        [Route("MemberEmailRepeat")]
        public MemberEmailRepeatServiceResult MemberEmailRepeat(string Email)
        {
            MemberEmailRepeatServiceResult result;
            MemberEmailRepeatService service = new MemberEmailRepeatService
            {
                Resources = new MemberEmailRepeatServiceCondition
                {
                    Email = Email,
                }
            };
            if (service.Check())
            {
                result = service.Work();
            }
            else
            {
                result = new MemberEmailRepeatServiceResult()
                {
                    Result = service.State,
                    ErrorMessage = service.StateMessage
                };
            }
            return result;
        }
    }
}
