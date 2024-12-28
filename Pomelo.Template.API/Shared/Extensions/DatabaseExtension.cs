using Pomelo.Template.API.Database;

namespace Pomelo.Template.API.Shared.Extensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>();

        
        return services;
    }
}