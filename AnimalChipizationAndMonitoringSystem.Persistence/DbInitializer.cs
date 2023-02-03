using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AnimalChipizationAndMonitoringDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
