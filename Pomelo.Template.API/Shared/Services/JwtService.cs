using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pomelo.Template.API.Shared.Options;

namespace Pomelo.Template.API.Shared.Services;

public class JwtService : IJwtService
{
    private readonly JwtOption _options;

    public JwtService(IOptions<JwtOption> options)
    {
        _options = options.Value;
    }
    
    public string GenerateToken(Dictionary<string, string> claimValues)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.Key);

        List<Claim> claimsIdentities = [];
            
        foreach (var claim in claimValues)
        {
            claimsIdentities.Add(new Claim(claim.Key, claim.Value));
        }
        
        var signingCred = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        var descriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claimsIdentities),
            Expires = DateTime.UtcNow.AddHours(_options.Expiration),
            SigningCredentials = signingCred,
            Issuer = _options.Issuer,
            Audience = _options.Audience
        };

        var token = handler.CreateToken(descriptor);

        return handler.WriteToken(token);
    }
}