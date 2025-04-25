using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Vida.Domain.Entities.IdentityEntities;
using Vida.Domain.SpaceEntities;
using Vida.Domain.Entities.News;

namespace Vida.Persistence.Store;
public class StoreContext(DbContextOptions<StoreContext> options): IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //modelBuilder.ApplyConfiguration(new ProductConfigurations());
        //modelBuilder.ApplyConfiguration(new ProductBrandConfigurations());
        //modelBuilder.ApplyConfiguration(new ProductCategoryConfigurations());

        // -- New Way
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Space> Spaces { get; set; }
    public DbSet<Availability> Availabilities { get; set; }
	public DbSet<SpaceReservation> SpaceAvailabilities { get; set; }
	public DbSet<Course> Courses { get; set; }
	public DbSet<CourseReservation> CourseSessions { get; set; }

    public DbSet<News> News { get; set; }
}