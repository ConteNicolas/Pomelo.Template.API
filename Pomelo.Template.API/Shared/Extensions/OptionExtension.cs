using Pomelo.Template.API.Shared.Options;

namespace Pomelo.Template.API.Shared.Extensions;

public static class OptionExtension
{
    public static IServiceCollection RegisterOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOption>(configuration.GetSection(JwtOption.SectionName));
        return services;
    }
}