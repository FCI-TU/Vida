using Microsoft.Extensions.Options;
using Vida.Application.Models;
using Vida.Server.ServicesExtension;

namespace Vida.Server;
public static class DependencyInjection
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        var configuration = builder.Configuration;

        services.ConfigureAppSettingData(configuration);

        var serviceProvider = services.BuildServiceProvider();

        var databaseConnections = serviceProvider.GetRequiredService<IOptions<DatabaseConnections>>().Value;

		services.AddControllers();

        services.AddSwaggerServices();

        services.AddIdentityConfigurations();

		services.AddStoreContext(databaseConnections.StoreConnection);

		services.AddApplicationServices();

		services.AddCorsPolicy();
    }
}