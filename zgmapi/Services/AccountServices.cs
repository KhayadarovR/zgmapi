using zgmapi.Models;

namespace zgmapi.Services;

public class AccountServices
{
    private readonly AppDbContext _context;

    public AccountServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> Register(User user)
    {
       throw new NotImplementedException();
    }
}