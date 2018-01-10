using ObjectCollection.Interfaces;

namespace ObjectCollection.ServiceResults
{
    public class MemberLoginServiceResult : IServiceResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
