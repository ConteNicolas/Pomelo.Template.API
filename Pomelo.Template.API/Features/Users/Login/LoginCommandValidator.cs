using FluentValidation;

namespace Pomelo.Template.API.Features.Users.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty();
        
        RuleFor(x => x.Password)
            .MinimumLength(8)
            .NotEmpty();
    }
}