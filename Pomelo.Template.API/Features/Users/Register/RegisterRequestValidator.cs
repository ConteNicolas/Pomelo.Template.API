using FastEndpoints;
using FluentValidation;

namespace Pomelo.Template.API.Features.Users.Register;

public class RegisterRequestValidator : Validator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty();

        RuleFor(x => x.Password)
            .MinimumLength(8)
            .NotEmpty();

        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
    }
}