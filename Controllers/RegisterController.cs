using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.DbConnection;
using UniversityApp.Middleware.ErrorHandling;
using UniversityApp.Middleware.Validation;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        [HttpPost(Name="Create")]
        public CreateResponse Create(RegisterRequest req)
        {
            CreateResponse createResponse= new CreateResponse();
            //Validation
            if (RegisterValidation.CheckName(req.Name) &&
                RegisterValidation.CheckPhone(req.Phone) &&
                RegisterValidation.CheckUser(req.User))

            {
                // add user to db
                using (Context db = new Context())
                {                    
                    db.Users.Add(req);
                    db.SaveChanges();
                }
                createResponse.ResponseMsg = "Success";
                createResponse.ErrorCode = (int)ErrorType.Success;
                createResponse.ErrorMsg = ErrorType.Success;

            }
            else
            {
                createResponse.ResponseMsg = "Vad user";
                createResponse.ErrorCode = (int)ErrorType.Error;
                createResponse.ErrorMsg = ErrorType.Error;
            }
            return createResponse;
        }

        // test connection
        [HttpGet]
        public IEnumerable<RegisterRequest> get()
        {
            List<RegisterRequest> users = new List<RegisterRequest>();
            using (Context db = new Context())
            {
                users = db.Users.ToList();
            }
            return users;
        }

    }
}
