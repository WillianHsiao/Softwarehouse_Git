using ObjectCollection.Interfaces;

namespace ObjectCollection.ServiceResults
{
    public class MemberSendResetPasswordEmailServiceResult : IServiceResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
