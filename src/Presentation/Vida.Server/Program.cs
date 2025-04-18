using Microsoft.EntityFrameworkCore;
using Vida.Persistence.Store;
using Vida.Server;
using Vida.Server.ServicesExtension;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container

builder.AddDependencies();

#endregion

var app = builder.Build();

#region Update Database With Using Way And Seeding Data

// We Said To Update Database You Should Do Two Things (1. Create Instance From DbContext 2. Migrate It)

// To Ask Clr To Create Instance Explicitly From Any Class
//    1 ->  Create Scope (Life Time Per Request)
using var scope = app.Services.CreateScope();
//    2 ->  Bring Service Provider Of This Scope
var services = scope.ServiceProvider;

// --> Bring Object Of StoreContext For Update His Migration
var storeContext = services.GetRequiredService<StoreContext>();
// --> Bring Object Of ILoggerFactory For Good Show Error In Console
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
	// Migrate StoreContext
	await storeContext.Database.MigrateAsync();
	// Seeding Data For StoreContext
	await StoreContextSeed.SeedProductDataAsync(storeContext);
}
catch (Exception ex)
{
	var logger = loggerFactory.CreateLogger<Program>();
	logger.LogError(ex, "an error has been occured during apply the migration!");
}

#endregion



if (app.Environment.IsDevelopment())
{
	app.UseSwaggerMiddleware();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();