using SQLite;

namespace FuelTracker.Models
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FuelLevel { get; set; }
        public int Mileage { get; set; }

    }
}
