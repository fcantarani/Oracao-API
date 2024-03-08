using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Oracap_App_API.Services;

public class AuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly string _token;

    public AuthService(ILogger<AuthService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _token = configuration["JWT_KEY"] ?? throw new ApplicationException("Parâmetro 'recupera_api_token' nulo ou inválido.");
        
    }
    public static object GenerateToke()
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(new ConfigurationBuilder().AddUserSecrets<Program>().Build()["JWT_KEY"] ?? "Cantarani"));

        var token = jwtHandler.CreateToken(new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(1),
            IssuedAt = DateTime.UtcNow,
            
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, "fabio.cantarani@gmail.com"),
                new Claim(ClaimTypes.Name, "Fabio Cantarani")
            }),
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
        });

        return jwtHandler.WriteToken(token);
    }
}
