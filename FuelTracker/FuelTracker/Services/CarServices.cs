using FuelTracker.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FuelTracker.Services
{
    public static class CarServices
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db == null)
            {
                string databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

                db = new SQLiteAsyncConnection(databasePath);

                await db.CreateTableAsync<Car>();
            }
        }

        public static async Task AddCar(string name, int fuelLevel, int tankCapacity, int mileage)
        {
            await Init();

            Car car = new Car
            {
                Name = name,
                FuelLevel = fuelLevel,
                TankCapacity = tankCapacity,
                Mileage = mileage
            };

            await db.InsertAsync(car);
        }

        public static async Task RemoveCar(int id)
        {
            await Init();

            await db.DeleteAsync<Car>(id);
        }

        public static async Task<IEnumerable<Car>> GetCar()
        {
            await Init();

            var car = await db.Table<Car>().ToListAsync();

            return car;
        }

        public static async Task<Car> GetCar(int id)
        {
            await Init();

            var car = await db.Table<Car>().FirstOrDefaultAsync(c => c.Id == id);

            return car;
        }

        public static async Task UpdateCar(Car car)
        {
            await Init();

            await db.UpdateAsync(car);
        }
    }
}
