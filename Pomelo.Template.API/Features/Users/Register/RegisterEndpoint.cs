using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Pomelo.Template.API.Features.Users.Register;

public class RegisterEndpoint : Endpoint<RegisterRequest>
{
    private readonly ISender _mediator;

    public RegisterEndpoint(ISender mediator)
    {
        _mediator = mediator;
    }
    
    public override void Configure()
    {
        Post("users/register");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var command = MapRequestToCommand(request);
        var result = await _mediator.Send(command, cancellationToken);
        
        if (result.IsFailure)
        {
            await SendAsync(result.Error.Message, StatusCodes.Status400BadRequest, cancellationToken);
        }

        await SendOkAsync(result.Value, cancellationToken);
    }
    
    private RegisterCommand MapRequestToCommand(RegisterRequest request)
    {
        return new RegisterCommand(request.Username, request.Password, request.Email);
    }
}