using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetAngular.Core.Domain.Vehicles;

namespace DotNetAngular.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(PgContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.VehicleTypes.Any())
            {
                return;   // DB has been seeded
            }

            var vehicleTypes = new VehicleType[]
            {
                new() { Name= "Bus", NumberOfPassengers = 42,CreateAt= DateTime.Now, UpdateAt = DateTime.Now },
                new() { Name= "Truck",NumberOfPassengers = 1, CreateAt= DateTime.Now, UpdateAt = DateTime.Now },
                new() { Name= "Car",NumberOfPassengers = 4, CreateAt= DateTime.Now, UpdateAt = DateTime.Now }

            };

            foreach (var t in vehicleTypes)
            {
                context.VehicleTypes.Add(t);
            }

            context.SaveChanges();
        }
    }
}
