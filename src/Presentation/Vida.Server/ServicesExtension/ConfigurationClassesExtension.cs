using Vida.Application.Models;

namespace Vida.Server.ServicesExtension;
public static class ConfigurationClassesExtension
{
    public static void ConfigureAppSettingData(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseConnections>(configuration.GetSection("ConnectionStrings"));

        services.Configure<JwtOptions>(configuration.GetSection("JWT"));
	}
}