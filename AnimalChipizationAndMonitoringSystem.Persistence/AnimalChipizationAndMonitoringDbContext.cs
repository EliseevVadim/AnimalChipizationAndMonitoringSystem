using AnimalChipizationAndMonitoringSystem.Application.Common.Interfaces;
using AnimalChipizationAndMonitoringSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Persistence
{
    public class AnimalChipizationAndMonitoringDbContext : DbContext, IAnimalChipizationAndMonitoringDbContext
    {
        public AnimalChipizationAndMonitoringDbContext()
            :base() { }

        public AnimalChipizationAndMonitoringDbContext(DbContextOptions<AnimalChipizationAndMonitoringDbContext> options)
            :base(options) { }

        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Animal> Animals { get; set; } = null!;
        public DbSet<AnimalType> AnimalTypes { get; set; } = null!;
        public DbSet<AnimalVisitedLocation> AnimalsVisitedLocations { get; set; } = null!;
        public DbSet<LocationPoint> LocationPoints { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory().Replace("Persistence", "WebApi"))
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseMySql(configuration["ConnectionString"], new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
