using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zgmapi.Models;

namespace zgmapi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private static List<User> _users = new List<User>()
        {
            new User() { Id = 1, Name = "raz"},
            new User() { Id = 2, Name = "rus"},
        };

        // GET users/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_users);
        }
    }
}
