using AnimalChipizationAndMonitoringSystem.Application.Extensions;
using AnimalChipizationAndMonitoringSystem.Persistence;
using AnimalChipizationAndMonitoringSystem.Persistence.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.File("AnimalsChipizationAndMonitoringSystem-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

using (var scopes = app.Services.CreateScope())
{
    try
    {
        var serviceProvider = scopes.ServiceProvider;
        AnimalChipizationAndMonitoringDbContext context = serviceProvider.GetRequiredService<AnimalChipizationAndMonitoringDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        Log.Fatal(exception, "An error occurred at app initialization");
    }
}

app.MapGet("/", () => "Hello World!");

app.Run();
