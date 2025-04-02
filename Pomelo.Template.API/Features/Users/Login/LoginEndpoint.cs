using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Pomelo.Template.API.Features.Users.Login;

public class LoginEndpoint : Endpoint<LoginRequest>
{
    private readonly ISender _mediator;

    public LoginEndpoint(ISender mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("users/login");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var command = MapRequestToCommand(request);
        var result = await _mediator.Send(command, cancellationToken);
        
        if (result.IsFailure)
        {
            await SendNotFoundAsync(cancellationToken);
        }

        await SendOkAsync(result.Value, cancellationToken);
    }
    
    private LoginCommand MapRequestToCommand(LoginRequest request)
    {
        return new LoginCommand(request.Username, request.Password);
    }
}