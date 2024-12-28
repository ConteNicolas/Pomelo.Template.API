using MediatR;
using Pomelo.Template.API.Shared.Models;

namespace Pomelo.Template.API.Features.Users.Register;

public record RegisterCommand(
    string Username,
    string Password,
    string Email
) : IRequest<Result<Guid>>;