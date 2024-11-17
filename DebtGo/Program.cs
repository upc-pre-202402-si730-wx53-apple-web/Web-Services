using DebtGo.Notification.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using NotificationsBC.Application.Internal.CommandServices;
using NotificationsBC.Infrastructure.Routing;
using DebtGo.Notification.Infrastructure.Persistence;
using DebtGo.Notification.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

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
app.UseAuthorization();

app.MapControllers();

app.Run();

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
