using DotNetAngular.Core.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAngular.Services.Vehicles
{
    public interface IVehicleService
    {
        Task<Vehicle> GetByIdAsync(int id);
        Task<IList<Vehicle>> GetAllAsync(Chassis chassis = null, int? vehicleTypeId = null, string color = null);
        Task InsertAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
        Task DeleteAsync(Vehicle vehicle);
    }
}
