using Pomelo.Template.API.Database.Abstractions;

namespace Pomelo.Template.API.Database.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime LastLogin { get; set; }
}