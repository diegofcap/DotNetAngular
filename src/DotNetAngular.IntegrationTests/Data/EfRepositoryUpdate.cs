using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetAngular.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DotNetAngular.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task UpdatesItemAfterAddingIt()
        {
            var vehicleService = GetService();

            var chassisSeries = Guid.NewGuid().ToString();

            Random generator = new Random();
            var chassisNumber = generator.Next(0, 1000000);

            var vehicle = new Vehicle
            {
                Chassis = new Chassis
                {
                    Number = chassisNumber,
                    Series = chassisSeries,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                },
                VehicleTypeId = 1,
                Color = "Black",
                NumberPassengers = 42,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            await vehicleService.InsertAsync(vehicle);

            var newVehicle = (await vehicleService.GetAllAsync(chassis: new Chassis
                {
                    Number = chassisNumber,
                    Series = chassisSeries
                }))
                .FirstOrDefault();
            Assert.NotNull(newVehicle);

            newVehicle.Color = "White";

            // Update the item
            await vehicleService.UpdateAsync(newVehicle);

            // Fetch the updated item
            var updatedItem = (await vehicleService.GetAllAsync(chassis: new Chassis
                {
                    Number = chassisNumber,
                    Series = chassisSeries
                }))
                .FirstOrDefault();

            Assert.NotNull(updatedItem);
            Assert.NotEqual("Black", updatedItem.Color);
            Assert.Equal(newVehicle.Id, updatedItem.Id);
        }
    }
}
