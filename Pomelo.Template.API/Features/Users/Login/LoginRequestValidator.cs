using FastEndpoints;

namespace Pomelo.Template.API.Features.Users.Login;

public class LoginRequestValidator : Validator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty();
        
        RuleFor(x => x.Password)
            .MinimumLength(8)
            .NotEmpty();
    }
}