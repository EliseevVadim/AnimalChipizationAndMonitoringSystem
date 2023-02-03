using AnimalChipizationAndMonitoringSystem.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.

namespace AnimalChipizationAndMonitoringSystem.Persistence.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionString"];
            services.AddDbContext<AnimalChipizationAndMonitoringDbContext>(options =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11)));
            });
            services.AddScoped<IAnimalChipizationAndMonitoringDbContext>(provider => provider.GetService<AnimalChipizationAndMonitoringDbContext>());
            return services;
        }
    }
}
