using System.Globalization;
using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pomelo.Template.API.Database;
using Pomelo.Template.API.Shared.Models;
using Pomelo.Template.API.Shared.Services;
using Pomelo.Template.API.Shared.Utils;

namespace Pomelo.Template.API.Features.Users.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
{
    private readonly IJwtService _jwtService;
    private readonly ApplicationDbContext _context;
    
    public LoginCommandHandler(IJwtService jwtService, ApplicationDbContext context)
    {
        _jwtService = jwtService;
        _context = context;
    }
    
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        
        var userFound = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == PasswordUtil.HashPassword(request.Password), cancellationToken);

        if (userFound is null)
        {
            return Result.Failure<string>(new Error("Error.UserNotFound", "User not found"));
        }
        
        var token = _jwtService.GenerateToken(new Dictionary<string, string>
        {
            {nameof(ClaimTypes.NameIdentifier), userFound.Id.ToString()},
            {nameof(ClaimTypes.Name), userFound.Username},
            {nameof(ClaimTypes.Expiration), DateTime.UtcNow.AddHours(1).ToString(CultureInfo.InvariantCulture)}
        });
        
        return Result.Success(token);
    }
}