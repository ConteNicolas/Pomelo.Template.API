namespace Pomelo.Template.API.Shared.Options;

public class JwtOption
{
    public const string SectionName = "Jwt";
    
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int Expiration { get; set; }
}