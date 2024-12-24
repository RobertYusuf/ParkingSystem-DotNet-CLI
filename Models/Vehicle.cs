using ParkingSystem.Utilities;

namespace ParkingSystem.Models
{
    public class Vehicle
    {
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public VehicleType Type { get; set; }
    }
}