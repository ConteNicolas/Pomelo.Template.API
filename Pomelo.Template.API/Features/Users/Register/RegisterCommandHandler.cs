using MediatR;
using Microsoft.EntityFrameworkCore;
using Pomelo.Template.API.Database;
using Pomelo.Template.API.Database.Entities;
using Pomelo.Template.API.Shared.Models;
using Pomelo.Template.API.Shared.Utils;

namespace Pomelo.Template.API.Features.Users.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<Guid>>
{
    private readonly ApplicationDbContext _context;

    public RegisterCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userAlreadyExists = await _context.Users.AnyAsync(
            x => x.Username.ToLower() == request.Username.ToLower() || x.Email.ToLower() == request.Email.ToLower(),
            cancellationToken);

        if (userAlreadyExists)
        {
            return Result.Failure<Guid>(new Error("Error.UsernameAlreadyExists", "Username already exists"));
        }

        var entity = MapRequestToEntity(request);

        _context.Users.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(entity.Id);
    }

    private User MapRequestToEntity(RegisterCommand request)
    {
        return new User
        {
            Username = request.Username,
            Password = PasswordUtil.HashPassword(request.Password),
            Email = request.Email
        };
    }
}