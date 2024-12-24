using System.Collections.Generic;

namespace ParkingSystem.Models
{
    public class ParkingLot
    {
        public int TotalSlots { get; private set; }
        public Dictionary<int, Vehicle> OccupiedSlots { get; private set; }

        public ParkingLot(int totalSlots)
        {
            TotalSlots = totalSlots;
            OccupiedSlots = new Dictionary<int, Vehicle>();
        }

        public int GetAvailableSlots() => TotalSlots - OccupiedSlots.Count;

        public bool IsSlotAvailable() => GetAvailableSlots() > 0;
    }
}