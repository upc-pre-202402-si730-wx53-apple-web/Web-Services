<<<<<<< Updated upstream
<<<<<<< Updated upstream
using DebtGo.Notification.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using NotificationsBC.Application.Internal.CommandServices;
using NotificationsBC.Infrastructure.Routing;
using DebtGo.Notification.Infrastructure.Persistence;
using DebtGo.Notification.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

=======
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
using DebtGo.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using DebtGo.Notification.Application.Internal.CommandServices;
using DebtGo.Notification.Application.Internal.QueryServices;
using DebtGo.Notification.Domain.Repositories;
using DebtGo.Notification.Domain.Services;
using DebtGo.Notification.Infrastructure.Persistence.EFC.Repositories;
using DebtGo.Shared.Domain.Repositories;
using DebtGo.Shared.Infrastructure.Persistence.EFC.Configuration;
using DebtGo.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Configure Swagger Endpoints and UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection String
if (connectionString is null)
    // Stop the application id the connection string is not set.
    throw new Exception("Database connection string is not set.");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
        });

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Notification Bounded Context Injection Configuration
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationCommandService, NotificationCommandService>();
builder.Services.AddScoped<INotificationQueryService, NotificationQueryService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

=======
using DebtGo.Notification.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using NotificationsBC.Application.Internal.CommandServices;
using NotificationsBC.Infrastructure.Routing;
using DebtGo.Notification.Infrastructure.Persistence;
using DebtGo.Notification.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
// Configurar DbContext para usar MySQL
builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios al contenedor.
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<NotificationCommandService>();

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseRouteNamingConvention()));
});

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotificationsBC API v1");
        c.RoutePrefix = string.Empty; // Swagger será accesible en la raíz
    });
}

app.UseStaticFiles();
app.UseRouting();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
=======
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
app.UseAuthorization();

app.MapControllers();

<<<<<<< HEAD
app.Run();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
app.Run();
>>>>>>> Stashed changes
=======
=======
app.Run();
>>>>>>> Stashed changes

// Implementación de KebabCaseRouteNamingConvention
public class KebabCaseRouteNamingConvention : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null) return null;

        return System.Text.RegularExpressions.Regex.Replace(
            value.ToString() ?? string.Empty,
            "([a-z])([A-Z])",
            "$1-$2").ToLowerInvariant();
    }
}
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
=======
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
