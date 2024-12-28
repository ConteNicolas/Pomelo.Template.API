namespace Pomelo.Template.API.Shared.Services;

public interface IJwtService
{
    public string GenerateToken(Dictionary<string, string> claimValues);
}