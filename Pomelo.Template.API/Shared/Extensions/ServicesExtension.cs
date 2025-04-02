using Pomelo.Template.API.Shared.Services;

namespace Pomelo.Template.API.Shared.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddTransient<IJwtService, JwtService>();

        return services;
    }       
}