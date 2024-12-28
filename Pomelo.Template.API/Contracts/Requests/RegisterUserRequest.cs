namespace Pomelo.Template.API.Contracts.Requests;

public record RegisterUserRequest(
    string Username,
    string Password,
    string Email
);