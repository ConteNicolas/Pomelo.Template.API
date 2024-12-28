using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Pomelo.Template.API.Contracts.Requests;

namespace Pomelo.Template.API.Features.Users.Register;

public class RegisterEndpoint : Endpoint< RegisterUserRequest, Results< Ok<Guid>, BadRequest<string>>>
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
    
    public override async Task<Results<Ok<Guid>, BadRequest<string>>> HandleAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var command = MapRequestToCommand(request);
        var result = await _mediator.Send(command, cancellationToken);
        
        if (result.IsFailure)
        {
            return TypedResults.BadRequest(result.Error.Message);
        }

        return TypedResults.Ok(result.Value);
    }
    
    private RegisterCommand MapRequestToCommand(RegisterUserRequest request)
    {
        return new RegisterCommand(request.Username, request.Password, request.Email);
    }
}