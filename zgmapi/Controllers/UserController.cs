using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zgmapi.Models;

namespace zgmapi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context)
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