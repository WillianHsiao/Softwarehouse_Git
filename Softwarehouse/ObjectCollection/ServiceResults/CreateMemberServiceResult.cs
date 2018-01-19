using ObjectCollection.Interfaces;

namespace ObjectCollection.ServiceResults
{
    public class CreateMemberServiceResult : IServiceResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
