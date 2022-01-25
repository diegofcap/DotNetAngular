#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetAngular.Core.Domain.Vehicles;
using DotNetAngular.Data.Context;
using DotNetAngular.Services.Vehicles;

namespace DotNetAngular.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return Ok(await _vehicleService.GetAllAsync());
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicleType = await _vehicleService.GetByIdAsync(id);

            if (vehicleType == null)
            {
                return NotFound();
            }

            return vehicleType;
        }

        [HttpPost]
        [Route("GetVehicleByChassis")]
        public async Task<ActionResult<Vehicle>> GetVehicleByChassis(Chassis model)
        {
            try
            {
                return Ok((await _vehicleService.GetAllAsync(chassis: model)).FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            try
            {
                await _vehicleService.UpdateAsync(vehicle);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            await _vehicleService.InsertAsync(vehicle);

            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            await _vehicleService.DeleteAsync(vehicle);

            return NoContent();
        }

        private bool VehicleExists(int id)
        {
            return _vehicleService.GetByIdAsync(id) != null;
        }
    }
}
