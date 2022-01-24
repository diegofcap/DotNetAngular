using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetAngular.Core.Domain.Vehicles;
using Xunit;

namespace DotNetAngular.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsVehicleAndSetsId()
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

            Assert.Equal(chassisSeries, newVehicle?.Chassis?.Series);
            Assert.Equal(chassisNumber, newVehicle?.Chassis?.Number);
            Assert.True(newVehicle?.Id > 0);
        }
    }
}
