using ObjectCollection.Interfaces;
using Common.Enums;

namespace ObjectCollection.ServiceResults
{
    public class MemberLoginServiceResult : IServiceResult
    {
        public LoginResultEnum LoginResult { get; set; }
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
