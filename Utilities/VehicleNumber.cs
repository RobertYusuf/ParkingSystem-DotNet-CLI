using System;

namespace ParkingSystem.Utilities
{
    public static class VehicleNumberHelper
    {
        public static bool IsOddNumberPlate(string licensePlate)
        {
            if (int.TryParse(licensePlate[^1].ToString(), out int lastDigit))
                return lastDigit % 2 != 0;

            return false;
        }
    }
}