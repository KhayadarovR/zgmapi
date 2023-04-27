using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using zgmapi.Data;
using zgmapi.Models;

namespace zgmapi.Services;

public class AccountServices
{
    private readonly AppDbContext _context;

    public AccountServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<JwtSecurityToken> Register(User user)
    {
        user.RoleId = 1;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        var newUser = await _context.Users.FirstAsync(u => u.Phone == user.Phone);
        var claims = SetClaims(newUser);
        var jwt = CreateJwt(claims);    
        return jwt;
    }

    private JwtSecurityToken CreateJwt(List<Claim> claims)
    {
        var jwt = new JwtSecurityToken(
            issuer: JwtOptions.ISSUER,
            audience: JwtOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(),
                                                    SecurityAlgorithms.HmacSha256)
        );
        return jwt;
    }

    private List<Claim> SetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(MyClaimTypes.Phone, user.Phone),
            new Claim(MyClaimTypes.Id, user.Id.ToString()),
            new Claim(MyClaimTypes.Role, user.RoleId.ToString())
        };
        return claims;
    }
}