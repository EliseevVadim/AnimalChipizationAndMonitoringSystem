using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChipizationAndMonitoringSystem.Application.Common.Exceptions
{
    public class ForbiddenActionException : Exception
    {
        public ForbiddenActionException(string message)
            : base(message) { }
    }
}
