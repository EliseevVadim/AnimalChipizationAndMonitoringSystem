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
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.HasKey(animalType => animalType.Id);
            builder.Property(animalType => animalType.Id).ValueGeneratedOnAdd();
            builder.HasMany(animalType => animalType.Animals)
                .WithMany(animal => animal.AnimalTypes)
                .UsingEntity(j => j.ToTable("AnimalsHaveTypes"));
        }
    }
}
