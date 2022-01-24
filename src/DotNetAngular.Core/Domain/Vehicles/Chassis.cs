using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAngular.Core.Domain.Vehicles
{
    public class Chassis : BaseEntity
    {
        public Chassis()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public string Series { get; set; }
        public int Number { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
