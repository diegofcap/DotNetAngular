using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetAngular.Core.Domain.Vehicles;

namespace DotNetAngular.Services.Vehicles
{
    public interface IVehicleTypeService
    {
        Task<VehicleType> GetByIdAsync(int id);
        Task<IList<VehicleType>> GetAllAsync(string name = null);
        Task InsertAsync(VehicleType vehicleType);
        Task UpdateAsync(VehicleType vehicleType);
        Task DeleteAsync(VehicleType vehicleType);
    }
}
