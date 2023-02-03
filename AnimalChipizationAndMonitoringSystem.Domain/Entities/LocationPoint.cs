using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Domain.Entities
{
    public class LocationPoint
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<AnimalVisitedLocation> AnimalVisits { get; set; }
        public List<Animal> AnimalsAtLocation { get; set; }
    }
}
