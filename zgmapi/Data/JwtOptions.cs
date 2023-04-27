
using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.IdentityModel.Tokens;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace zgmapi.Data;

public class JwtOptions
{
    public const string ISSUER = "zgmapi"; // издатель токена
    public const string AUDIENCE = "zgmclient"; // потребитель токена
    private static string KEY = "default";
    public static void SetKey(string configKey)
    {
        KEY = configKey;
    }
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}