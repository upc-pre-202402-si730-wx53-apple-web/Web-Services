using DebtGo.SubscriptionBC.Infrastructure.Data;
using DebtGo2.SubscriptionBC.Domain.Repositories;
using DebtGo2.SubscriptionBC.Application.Internal.CommandServices;
using DebtGo2.SubscriptionBC.Infrastructure.Persistence.EFC.Repositories;
using DebtGo2.SubscriptionBC.Interfaces.REST.Transform;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using DebtGo.SubscriptionBC.Domain.Services;
using DebtGo2.Shared.Domain.Repositories;
using DebtGo2.Shared.Infrastructure.Persistence.EFC;
using DebtGo2.SubscriptionBC.Application.Internal.QueryServices;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
///     Configures CORS to allow all origins, headers, and methods.
/// </summary>
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

/// <summary>
///     Adds controllers to the services collection.
/// </summary>
builder.Services.AddControllers();

/// <summary>
///     Configures API documentation and exploration.
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
///     Configures the database context for MySQL.
/// </summary>
builder.Services.AddDbContext<SubscriptionDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    ));

/// <summary>
///     Registers specific repositories and services in the dependency injection container.
/// </summary>
builder.Services.AddScoped<DebtGo2.SubscriptionBC.Infrastructure.Persistence.EFC.Repositories.ISubscriptionRepository, SubscriptionRepository>(); // Subscription repository
builder.Services.AddScoped<ISubscriptionCommandService, DebtGo2.SubscriptionBC.Application.Internal.CommandServices.SubscriptionCommandService>(); // Command service
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>(); // Query service


/// <summary>
///     Registers assemblers for transforming entities to resources and vice versa.
/// </summary>
builder.Services.AddScoped<CreateSubscriptionCommandFromResourceAssembler>();
builder.Services.AddScoped<SubscriptionResourceFromEntityAssembler>();

/// <summary>
///     Registers shared services in the dependency injection container.
/// </summary>
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>)); // Generic base repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Unit of work for managing transactions

/// <summary>
///     Adds controllers with views to the services collection.
/// </summary>
builder.Services.AddControllersWithViews();

var app = builder.Build();

/// <summary>
///     Configures the error handling pipeline for non-development environments.
/// </summary>
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

/// <summary>
///     Enables static file serving.
/// </summary>
app.UseStaticFiles();

/// <summary>
///     Configures routing.
/// </summary>
app.UseRouting();

/// <summary>
///     Enforces HTTPS redirection.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
///     Enables the configured CORS policy.
/// </summary>
app.UseCors("AllowAll");

/// <summary>
///     Configures Swagger for API documentation.
/// </summary>
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Subscription API v1");
});

/// <summary>
///     Enables authorization middleware.
/// </summary>
app.UseAuthorization();

/// <summary>
///     Maps controller routes.
/// </summary>
app.MapControllers();

/// <summary>
///     Runs the application.
/// </summary>
app.Run();
