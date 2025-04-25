using Vida.Application.Interfaces.Repositories;
using Vida.Application.Interfaces.Services;
using Vida.Application.MappingProfıles;
using Vida.Infrastructure.Services;
using Vida.Persistence;

namespace Vida.Server.ServicesExtension;

public static class ApplicationServicesExtension
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

		services.AddScoped(typeof(ISpaceService), typeof(SpaceService));

		services.AddScoped(typeof(ICourseService), typeof(CourseService));

		services.AddScoped(typeof(IAvailabilityService), typeof(AvailabilityService));

		services.AddScoped(typeof(IJWTTokenGenerator), typeof(JWTTokenGenerator));

		services.AddScoped(typeof(IAuthService), typeof(AuthService));

        services.AddScoped(typeof(INewsService), typeof(NewsService));


        // --- Two Ways To Register AutoMapper
        // - First (harder)
        //builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
        // - Second (easier)
        services.AddAutoMapper(typeof(MappingProfiles));

		return services;
	}
}