
using System.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace zgmapi.Data;

public class JwtOptions
{
    public const string ISSUER = "zgmapi"; // издатель токена
    public const string AUDIENCE = "zgmclient"; // потребитель токена
    
    public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}