using DotNetAngular.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetAngular.Core.Domain.Vehicles;

namespace DotNetAngular.Services.Vehicles
{
    public class VehicleService : IVehicleService
    {
        #region Fields
        private readonly IRepository<Vehicle> _vehicleRepository;
        #endregion

        #region Ctor

        public VehicleService(IRepository<Vehicle> vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;

        }
        #endregion

        #region Methods

        public virtual async Task DeleteAsync(Vehicle vehicle)
        {
            await _vehicleRepository.DeleteAsync(vehicle);

        }

        public virtual async Task<IList<Vehicle>> GetAllAsync(Chassis chassis = null, int? vehicleTypeId = null, string color = null)
        {
            return await _vehicleRepository.GetAllAsync(async query =>
            {
                if (vehicleTypeId.HasValue)
                    query = query.Where(v => v.VehicleTypeId == vehicleTypeId);

                if (chassis != null)
                    query = query.Where(v => v.Chassis.Number == chassis.Number && v.Chassis.Series == chassis.Series);

                if (!string.IsNullOrEmpty(color))
                    query = query.Where(v => v.Color == color);

                return query;

            });
        }

        public virtual async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _vehicleRepository.GetByIdAsync(id);
        }

        public virtual async Task InsertAsync(Vehicle vehicle)
        {
            await _vehicleRepository.InsertAsync(vehicle);
        }

        public virtual async Task UpdateAsync(Vehicle vehicle)
        {
            await _vehicleRepository.UpdateAsync(vehicle);
        }
        #endregion
    }
}
