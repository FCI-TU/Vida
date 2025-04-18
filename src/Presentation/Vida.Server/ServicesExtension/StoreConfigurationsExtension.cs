using Microsoft.EntityFrameworkCore;
using Vida.Persistence.Store;

namespace Vida.Server.ServicesExtension;
public static class StoreConfigurationsExtension
{
    public static void AddStoreContext(this IServiceCollection services, string storeConnection)
    {
        services.AddDbContext<StoreContext>(options =>
        {
            options.UseSqlServer(storeConnection);
        });
    }

}