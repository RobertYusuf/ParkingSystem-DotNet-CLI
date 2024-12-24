using ParkingSystem.Models;

namespace ParkingSystem.Services
{
    public interface IParkingService
    {
        void CheckIn(Vehicle vehicle);
        void CheckOut(string licensePlate);
        void GenerateReport();
    }
}