using ObjectCollection.Interfaces;

namespace ObjectCollection.ServiceResults
{
    public class MemberAccountRepeatServiceResult : IServiceResult
    {
        public bool IsRepeat { get; set; }
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
