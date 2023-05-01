using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zgmapi.Models;
using zgmapi.Services;

namespace zgmapi.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly AccountServices _account;

    public AccountController(AppDbContext context, AccountServices _account)
    {
        _context = context;
        this._account = _account;
    }

    // GET: api/Account
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        if (_context.Users == null)
        {
            return NotFound();
        }

        return await _context.Users.ToListAsync();
    }

    // GET: api/Account/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(long id)
    {
        if (_context.Users == null)
        {
            return NotFound();
        }
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/Account/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(long id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Account
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<string> PostUser(User user)
    {
        var jwt = await _account.Register(user);
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }   

    // DELETE: api/Account/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        if (_context.Users == null)
        {
            return NotFound();
        }
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(long id)
    {
        return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}