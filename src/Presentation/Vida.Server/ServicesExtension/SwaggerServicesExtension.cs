namespace Vida.Server.ServicesExtension;
public static class SwaggerServicesExtension
{
    public static void AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
    }

    public static void UseSwaggerMiddleware(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI();
    }
}