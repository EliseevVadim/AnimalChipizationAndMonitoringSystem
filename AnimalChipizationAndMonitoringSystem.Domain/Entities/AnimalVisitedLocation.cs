using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Domain.Entities
{
    public class AnimalVisitedLocation
    {
        public long Id { get; set; }
        public long AnimalId { get; set; }
        public Animal Animal { get; set; }
        public long LocationPointId { get; set; }
        public LocationPoint LocationPoint { get; set; }
        public DateTime DateTimeOfVisitLocationPoint { get; set; }
    }
}
