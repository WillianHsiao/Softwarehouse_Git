using ObjectCollection.Interfaces;

namespace ObjectCollection.ServiceResults
{
    public class CreateMemberServiceResult : IServiceResult
    {
        public string ErrorMessage { get; set; }

        public bool Result { get; set; }
    }
}
