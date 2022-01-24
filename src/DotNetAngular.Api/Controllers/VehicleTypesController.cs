using DotNetAngular.Core.Domain.Vehicles;
using DotNetAngular.Services.Vehicles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetAngular.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleTypesController : ControllerBase
    {
        #region Fields
        private IVehicleTypeService _vehicleTypeService;
        #endregion

        #region ctor

        public VehicleTypesController(IVehicleTypeService vehicleTypeService)
        {
            this._vehicleTypeService = vehicleTypeService;
        }

        #endregion

        #region Methods
        // GET: api/VehicleTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleType>>> GetVehicleType(string name)
        {
            return Ok(await _vehicleTypeService.GetAllAsync(name));
        }

        // GET: api/VehicleTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleType>> GetVehicleType(int id)
        {
            var paymentMethod = await _vehicleTypeService.GetByIdAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return paymentMethod;
        }

        // PUT: api/VehicleTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleType(int id, VehicleType vehicleType)
        {
            if (id != vehicleType.Id)
            {
                return BadRequest();
            }

            try
            {
                await _vehicleTypeService.UpdateAsync(vehicleType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehicleTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VehicleType>> PostVehicleType(VehicleType vehicleType)
        {
            await _vehicleTypeService.InsertAsync(vehicleType);

            return CreatedAtAction("GetVehicleType", new { id = vehicleType.Id }, vehicleType);
        }

        // DELETE: api/VehicleTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleType>> DeleteVehicleType(int id)
        {
            var vehicleType = await _vehicleTypeService.GetByIdAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            await _vehicleTypeService.DeleteAsync(vehicleType);

            return vehicleType;
        }

        private bool VehicleTypeExists(int id)
        {
            return _vehicleTypeService.GetByIdAsync(id) != null;
        }


        #endregion
    }
}
