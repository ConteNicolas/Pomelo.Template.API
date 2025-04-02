namespace Pomelo.Template.API.Features.Users.Register;

public record RegisterRequest(
    string Username,
    string Password,
    string Email
);