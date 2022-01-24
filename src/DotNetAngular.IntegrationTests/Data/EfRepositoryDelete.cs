using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetAngular.Core.Domain.Vehicles;
using Xunit;

namespace DotNetAngular.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesItemAfterAddingIt()
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

            //insert the item
            await vehicleService.InsertAsync(vehicle);

            // delete the item
            await vehicleService.DeleteAsync(vehicle);

            // verify it's no longer there
            Assert.DoesNotContain((await vehicleService.GetAllAsync(chassis: new Chassis
                {
                    Number = chassisNumber,
                    Series = chassisSeries
                })), v => v?.Chassis?.Number == chassisNumber && v?.Chassis?.Series == chassisSeries);
        }
    }
}
