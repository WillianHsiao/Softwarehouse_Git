using Business.Services;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Softwarehouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
