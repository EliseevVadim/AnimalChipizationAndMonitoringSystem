using AnimalChipizationAndMonitoringSystem.Domain.Entities;
using AnimalChipizationAndMonitoringSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Persistence.EntityConfigurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(animal => animal.Id);
            builder.Property(animal => animal.Id).ValueGeneratedOnAdd();
            builder.Property(animal => animal.Gender)
                .HasConversion(
                    value => value.ToString(),
                    value => (Gender)Enum.Parse(typeof(Gender), value)
                );
            builder.Property(animal => animal.LifeStatus)
                .HasConversion(
                    value => value.ToString(),
                    value => (LifeStatus)Enum.Parse(typeof(LifeStatus), value)
                );
            builder.HasMany(animal => animal.VisitedLocations)
                .WithOne(visitedLocation => visitedLocation.Animal)
                .HasForeignKey(visitedLocation => visitedLocation.AnimalId);
            builder.HasOne(animal => animal.Chipper)
                .WithMany(account => account.ChippedAnimals)
                .HasForeignKey(animal => animal.ChipperId);
            builder.HasOne(animal => animal.ChippingLocation)
                .WithMany(location => location.AnimalsAtLocation)
                .HasForeignKey(animal => animal.ChippingLocationId);
        }
    }
}
