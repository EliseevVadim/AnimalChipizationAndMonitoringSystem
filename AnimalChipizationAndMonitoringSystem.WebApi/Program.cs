using AnimalChipizationAndMonitoringSystem.Application.Common.Interfaces;
using AnimalChipizationAndMonitoringSystem.Application.Common.Mappings;
using AnimalChipizationAndMonitoringSystem.Application.Extensions;
using AnimalChipizationAndMonitoringSystem.Persistence;
using AnimalChipizationAndMonitoringSystem.Persistence.Extensions;
using AnimalChipizationAndMonitoringSystem.WebApi.Extensions;
using Serilog;
using Serilog.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.File("AnimalsChipizationAndMonitoringSystem-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IAnimalChipizationAndMonitoringDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("InitialPolicy", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

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

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseCors("InitialPolicy");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
