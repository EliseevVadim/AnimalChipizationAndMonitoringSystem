using AnimalChipizationAndMonitoringSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Domain.Entities
{
    public class Animal
    {
        public long Id { get; set; }
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public Gender Gender { get; set; }
        public LifeStatus LifeStatus { get; set; }
        public DateTime ChippingDateTime { get; set; }
        public int ChipperId { get; set; }
        public Account Chipper { get; set; }
        public long ChippingLocationId { get; set; }
        public LocationPoint ChippingLocation { get; set; }
        public List<AnimalVisitedLocation> VisitedLocations { get; set; }
        public List<AnimalType> AnimalTypes { get; set; } = new List<AnimalType>();
        public DateTime DeathDateTime { get; set; }
    }
}
