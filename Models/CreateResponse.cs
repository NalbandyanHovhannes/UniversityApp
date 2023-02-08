using UniversityApp.Middleware.ErrorHandling;

namespace UniversityApp.Models
{
    public class CreateResponse
    {
        public ErrorType ErrorMsg { get; set; }
        public int ErrorCode { get; set; }
        public string ResponseMsg { get; set; }

    }
}
