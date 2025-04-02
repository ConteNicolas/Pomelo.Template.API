namespace Pomelo.Template.API.Features.Users.Login;

public record LoginRequest(
    string Username,
    string Password
);