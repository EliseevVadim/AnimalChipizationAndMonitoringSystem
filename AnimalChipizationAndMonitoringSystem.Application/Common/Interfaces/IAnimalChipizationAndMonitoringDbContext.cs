using AnimalChipizationAndMonitoringSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Application.Common.Interfaces
{
    public interface IAnimalChipizationAndMonitoringDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<AnimalVisitedLocation> AnimalsVisitedLocations { get; set; }
        public DbSet<LocationPoint> LocationPoints { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
