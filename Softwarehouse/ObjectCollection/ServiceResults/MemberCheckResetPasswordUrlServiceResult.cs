using ObjectCollection.Interfaces;

namespace ObjectCollection.ServiceResults
{
    public class MemberCheckResetPasswordUrlServiceResult : IServiceResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
