using Microsoft.AspNetCore.Mvc;
using UniversityApp.DbConnection;
using UniversityApp.Middleware.ErrorHandling;
using UniversityApp.Models;

namespace UniversityApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeleteController : Controller
{
    // DELETE
    [HttpPost(Name="Delete")]
    public CreateResponse DeleteResponse (DeleteRequest reqDel)
    {
        CreateResponse deleteResponse = new CreateResponse();
        using (Context db = new Context())
        {
            RegisterController userList = new RegisterController();
            {
                foreach (var user in RegisterController.get())
                {
                    if (reqDel.Id == user.ID)
                    {
                        {
                            user.StatusId = 1;
                            db.SaveChanges();
                        }
                        break;
                    }

                    else
                    {
                        deleteResponse.ResponseMsg = "User not found";
                        deleteResponse.ErrorCode = (int)ErrorType.NotFound;
                        deleteResponse.ErrorMsg = ErrorType.NotFound;
                    }
                }
            }
        }
        deleteResponse.ResponseMsg = $"User no. {reqDel.Id} deleted.";
        deleteResponse.ErrorCode = (int)ErrorType.Success;
        deleteResponse.ErrorMsg = ErrorType.Success;
        return deleteResponse;
    }
}