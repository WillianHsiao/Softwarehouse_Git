using Business.Services;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using System.Threading.Tasks;
using System.Web.Http;

namespace Softwarehouse.Controllers
{
    [RoutePrefix("api/forgotpassword")]
    public class ForgotPasswordApiController : ApiController
    {
        [HttpPost]
        [Route("SendResetPasswordEmail")]
        public async Task<MemberSendResetPasswordEmailServiceResult> SendResetPasswordEmail(string Email)
        {
            MemberSendResetPasswordEmailServiceResult result;
            MemberSendResetPasswordEmailService service = new MemberSendResetPasswordEmailService
            {
                Resources = new MemberSendResetPasswordEmailServiceCondition
                {
                    Email = Email
                }
            };
            if (service.Check())
            {
                result = await service.Work();
            }
            else
            {
                result = new MemberSendResetPasswordEmailServiceResult()
                {
                    Result = service.State,
                    ErrorMessage = service.StateMessage
                };
            }
            return result;
        }
    }
}
