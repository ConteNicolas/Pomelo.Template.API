using MediatR;
using Pomelo.Template.API.Shared.Models;

namespace Pomelo.Template.API.Features.Users.Login;

public record LoginCommand(
    string Username,
    string Password
) : IRequest<Result<string>>;