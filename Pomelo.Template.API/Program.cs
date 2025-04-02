global using FluentValidation;

using FastEndpoints;
using Pomelo.Template.API.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerWithJwt(builder.Configuration);

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.RegisterOptions(builder.Configuration);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddFastEndpoints();

builder.Services.InjectServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFastEndpoints();

app.UseHttpsRedirection();

app.Run();
