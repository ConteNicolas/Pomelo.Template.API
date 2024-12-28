using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Pomelo.Template.API.Contracts.Requests;

namespace Pomelo.Template.API.Features.Users.Login;

public class LoginEndpoint : Endpoint<LoginUserRequest,  Results<Ok<string>, NotFound>>
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
    
    public override async Task<Results<Ok<string>, NotFound>> HandleAsync(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var command = MapRequestToCommand(request);
        var result = await _mediator.Send(command, cancellationToken);
        
        if (result.IsFailure)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(result.Value);
    }
    
    private LoginCommand MapRequestToCommand(LoginUserRequest request)
    {
        return new LoginCommand(request.Username, request.Password);
    }
}