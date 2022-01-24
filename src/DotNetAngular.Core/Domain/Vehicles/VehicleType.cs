using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAngular.Core.Domain.Vehicles
{
    public class VehicleType : BaseEntity
    {
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public string Name { get; set; }
        public int NumberOfPassengers { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
