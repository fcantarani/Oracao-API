using Microsoft.AspNetCore.Mvc;
using Oracap_App_API.Services;

namespace Oracap_App_API.Controllers;

[ApiController]
[Route("api/v1/Auth")]
public class AuthController : Controller
{

    [HttpPost]
    public IActionResult Auth(string username, string password)
    {
        if (username == "fabio" && password == "teste123")
        {
            var token = AuthService.GenerateToke();
            return Ok(token);
        }
        return BadRequest("username or password invalid!");
    }
}
