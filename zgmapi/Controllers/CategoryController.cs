using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using zgmapi.Data;
using zgmapi.Models;
using zgmapi.Services;
namespace zgmapi.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController: ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }
    
    
    // GET: api/category
    [HttpGet]
    [Authorize(Roles = DefaultRoles.AdminString)]
    public async Task<ActionResult<IEnumerable<Category>>> GetUsers()
    {
        if (_context.Category == null)
        {
            return NotFound();
        }

        return await _context.Category.ToListAsync();
    }
}