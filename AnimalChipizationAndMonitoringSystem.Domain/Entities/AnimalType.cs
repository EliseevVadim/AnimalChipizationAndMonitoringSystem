using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Domain.Entities
{
    public class AnimalType
    {
        public long Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
}
