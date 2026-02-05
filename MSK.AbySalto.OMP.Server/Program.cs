using Microsoft.EntityFrameworkCore;
using MSK.AbySalto.OMP.Core.Interfaces;
using MSK.AbySalto.OMP.Core.Services;
using MSK.AbySalto.OMP.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

var a = builder.Configuration.GetConnectionString("webshopdb");
builder.AddNpgsqlDbContext<OMPContext>(connectionName: "webshopdb");

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IRepository, RepositoryAdapter>();
builder.Services.AddScoped<ProductsService, ProductsService>();
builder.Services.AddScoped<BasketService, BasketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapControllers();
var api = app.MapGroup("/api");
api.MapGet("weatherforecast", (OMPContext c) =>
{
    var a = c.Products.Count(); // to avoid warning
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapDefaultEndpoints();

app.UseFileServer();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<OMPContext>();
await DatabaseHelper.InitializeAsync(context);

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
