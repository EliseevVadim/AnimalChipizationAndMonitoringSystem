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
    public class AnimalVisitedLocationConfiguration : IEntityTypeConfiguration<AnimalVisitedLocation>
    {
        public void Configure(EntityTypeBuilder<AnimalVisitedLocation> builder)
        {
            builder.HasKey(animalVisitedLocation => animalVisitedLocation.Id);
            builder.Property(animalVisitedLocation => animalVisitedLocation.Id).ValueGeneratedOnAdd();
            builder.HasOne(animalVisitedLocation => animalVisitedLocation.LocationPoint)
                .WithMany(location => location.AnimalVisits)
                .HasForeignKey(animalVisitedLocation => animalVisitedLocation.LocationPointId);
            builder.HasOne(animalVisitedLocation => animalVisitedLocation.Animal)
                .WithMany(animal => animal.VisitedLocations)
                .HasForeignKey(animalVisitedLocation => animalVisitedLocation.AnimalId);
        }
    }
}
