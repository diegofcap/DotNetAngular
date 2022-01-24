using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAngular.Core.Domain.Vehicles
{
    public class Vehicle : BaseEntity
    {
        public int ChassisId { get; set; }
        public int VehicleTypeId { get; set; }
        public int NumberPassengers { get; set; }
        public string Color { get; set; }

        public virtual Chassis Chassis { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
