using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zgmapi.Models;
using AppContext = zgmapi.Models.AppContext;

namespace zgmapi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppContext _context;
    public UserController(AppContext context)
    {
        _context = context;
    }

    // GET users/
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Users);
    }
}