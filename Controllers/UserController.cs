using Microsoft.AspNetCore.Mvc;
using UniversityApp.DbConnection;
using UniversityApp.Middleware.ErrorHandling;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // DELETE
        [HttpPost]
        [Route("Delete")]
        public List<CreateResponse> Delete(List<DeleteRequest> reqDel)
        {
            List<CreateResponse> deleteResponse = new List<CreateResponse>();
            CreateResponse delValue = new CreateResponse();
            using (Context db = new Context())
            {

                for (int i = 0; i < reqDel.Count; i++)
                {// Find the user you want to edit
                    var user = db.Users.Find(reqDel[i].Id);

                    if (user != null)
                    {
                        user.StatusId = 1; // "locked user" status
                        db.SaveChanges();
                    }
                    else
                    {
                        delValue.ResponseMsg = "User not found";
                        delValue.ErrorCode = (int)ErrorType.NotFound;
                        delValue.ErrorMsg = ErrorType.NotFound;
                    }


                    delValue.ResponseMsg = $"User no. {reqDel[i].Id} deleted.";
                    delValue.ErrorCode = (int)ErrorType.Success;
                    delValue.ErrorMsg = ErrorType.Success;
                    deleteResponse.Add(delValue);
                }
            }
            return deleteResponse;
        }

        // UPDATE
        [HttpPost]
        [Route("Update")]

        public CreateResponse UpdateResponse(UpdateRequest reqUpdate)
        {
            CreateResponse updateResponse = new CreateResponse();
            using (Context db = new Context())
            {
                // Find the user you want to edit
                var user = db.Users.Find(reqUpdate.Id);

                if (user != null)
                {
                    user.Name = reqUpdate.Name;
                    user.Surname = reqUpdate.Surname;
                    user.User = reqUpdate.User;
                    user.Password = reqUpdate.Password;
                    user.Nickname = reqUpdate.Nickname;
                    user.Phone = reqUpdate.Phone;
                    db.SaveChanges();
                }
                else
                {
                    updateResponse.ResponseMsg = "User not found";
                    updateResponse.ErrorCode = (int)ErrorType.NotFound;
                    updateResponse.ErrorMsg = ErrorType.NotFound;
                }
            }
            updateResponse.ResponseMsg = $"User no. {reqUpdate.Id} updated.";
            updateResponse.ErrorCode = (int)ErrorType.Success;
            updateResponse.ErrorMsg = ErrorType.Success;
            return updateResponse;


        }

    }
}
