namespace Pomelo.Template.API.Contracts.Requests;

public record LoginUserRequest(
    string Username,
    string Password
);