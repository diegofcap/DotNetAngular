using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetAngular.Core.Domain.Vehicles;
using DotNetAngular.Data.Repository;

namespace DotNetAngular.Services.Vehicles
{
    public class VehicleTypeService : IVehicleTypeService
    {
        #region Fields
        private readonly IRepository<VehicleType> _vehicleTypeRepository;
        #endregion

        #region Ctor

        public VehicleTypeService(IRepository<VehicleType> vehicleTypeRepository)
        {
            this._vehicleTypeRepository = vehicleTypeRepository;

        }
        #endregion

        #region Methods

        public virtual async Task DeleteAsync(VehicleType vehicleType)
        {
            await _vehicleTypeRepository.DeleteAsync(vehicleType);

        }

        public virtual async Task<IList<VehicleType>> GetAllAsync(string name = null)
        {
            return await _vehicleTypeRepository.GetAllAsync(async query =>
            {
                if (!string.IsNullOrEmpty(name))
                    query = query.Where(v => v.Name == name);

                return query;

            });
        }

        public virtual async Task<VehicleType> GetByIdAsync(int id)
        {
            return await _vehicleTypeRepository.GetByIdAsync(id);
        }

        public virtual async Task InsertAsync(VehicleType vehicleType)
        {
            await _vehicleTypeRepository.InsertAsync(vehicleType);
        }

        public virtual async Task UpdateAsync(VehicleType vehicleType)
        {
            await _vehicleTypeRepository.UpdateAsync(vehicleType);
        }
        #endregion
    }
}
