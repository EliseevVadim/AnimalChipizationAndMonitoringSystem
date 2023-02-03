using AnimalChipizationAndMonitoringSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Persistence.EntityConfigurations
{
    public class LocationPointConfiguration : IEntityTypeConfiguration<LocationPoint>
    {
        public void Configure(EntityTypeBuilder<LocationPoint> builder)
        {
            builder.HasKey(location => location.Id);
            builder.Property(location => location.Id).ValueGeneratedOnAdd();
            builder.HasMany(location => location.AnimalVisits)
                .WithOne(animalVisitsLocation => animalVisitsLocation.LocationPoint)
                .HasForeignKey(animalVisitsLocation => animalVisitsLocation.LocationPointId);
            builder.HasMany(location => location.AnimalsAtLocation)
                .WithOne(animal => animal.ChippingLocation)
                .HasForeignKey(animal => animal.ChippingLocationId);
        }
    }
}
