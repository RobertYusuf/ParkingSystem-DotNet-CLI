using System;
using System.Linq;
using ParkingSystem.Models;
using ParkingSystem.Utilities;

namespace ParkingSystem.Services
{
    public class ParkingService : IParkingService
    {
        private readonly ParkingLot _parkingLot;

        public ParkingService(int totalSlots)
        {
            _parkingLot = new ParkingLot(totalSlots);
        }

        public void CheckIn(Vehicle vehicle)
        {
            if (!_parkingLot.IsSlotAvailable())
            {
                Console.WriteLine("No available slots.");
                return;
            }

            if (_parkingLot.OccupiedSlots.Values.Any(v => v.LicensePlate == vehicle.LicensePlate))
            {
                Console.WriteLine("Vehicle is already parked.");
                return;
            }

            int availableSlot = Enumerable.Range(1, _parkingLot.TotalSlots)
                                          .Except(_parkingLot.OccupiedSlots.Keys)
                                          .First();
            _parkingLot.OccupiedSlots[availableSlot] = vehicle;
            Console.WriteLine($"Vehicle parked at slot {availableSlot}.");
        }

        public void CheckOut(string licensePlate)
        {
            var slot = _parkingLot.OccupiedSlots.FirstOrDefault(s => s.Value.LicensePlate == licensePlate);

            if (slot.Key == 0)
            {
                Console.WriteLine("Vehicle not found.");
                return;
            }

            _parkingLot.OccupiedSlots.Remove(slot.Key);
            Console.WriteLine($"Vehicle with license plate {licensePlate} checked out from slot {slot.Key}.");
        }

        public void GenerateReport()
        {
            Console.WriteLine($"Total Slots: {_parkingLot.TotalSlots}");
            Console.WriteLine($"Occupied Slots: {_parkingLot.OccupiedSlots.Count}");
            Console.WriteLine($"Available Slots: {_parkingLot.GetAvailableSlots()}");

            var oddVehicles = _parkingLot.OccupiedSlots.Values
                .Count(v => VehicleNumberHelper.IsOddNumberPlate(v.LicensePlate));

            var evenVehicles = _parkingLot.OccupiedSlots.Values.Count - oddVehicles;

            Console.WriteLine($"Odd License Plates: {oddVehicles}");
            Console.WriteLine($"Even License Plates: {evenVehicles}");

            var vehicleTypes = _parkingLot.OccupiedSlots.Values
                .GroupBy(v => v.Type)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var type in vehicleTypes)
                Console.WriteLine($"{type.Key}: {type.Value}");

            var vehicleColors = _parkingLot.OccupiedSlots.Values
                .GroupBy(v => v.Color)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var color in vehicleColors)
                Console.WriteLine($"{color.Key} Vehicles: {color.Value}");
        }
    }
}