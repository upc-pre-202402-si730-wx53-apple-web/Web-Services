using DebtGo.SubscriptionBC.Infrastructure.Data;
using DebtGo.SubscriptionBC.Infrastructure.Repositories;
using DebtGo.SubscriptionBC.Domain.Services;
using DebtGo.SubscriptionBC.Application.Internal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/**
 * Configures the application services.
 */
builder.Services.AddEndpointsApiExplorer(); // Enables endpoint exploration for the API
builder.Services.AddSwaggerGen(); // Enables Swagger to generate API documentation

/**
 * Configures the database context using SQL Server.
 */
builder.Services.AddDbContext<SubscriptionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/**
 * Registers repositories and services in the dependency injection container.
 */
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();

builder.Services.AddControllersWithViews(); // Adds support for controllers and views

var app = builder.Build(); // Builds the application

/**
 * Configures the HTTP pipeline of the application.
 */
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Handles exceptions in production environments
}
app.UseStaticFiles(); // Enables the use of static files
app.UseRouting(); // Enables routing for requests
app.UseAuthorization(); // Enables authorization to protect resources
app.MapControllers(); // Maps controllers to routes

/**
 * Configures the default route for the application's controllers.
 */
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Subscription}/{action=GetAll}/{id?}");

/**
 * Enables Swagger and the Swagger UI for interactive documentation.
 */
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Subscription API v1");
});

app.Run(); // Runs the application
