using System;
using ParkingSystem.Models;
using ParkingSystem.Services;
using ParkingSystem.Utilities;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Parking System!");
            IParkingService parkingService = new ParkingService(10);

            while (true)
            {
                Console.WriteLine("\n1. Check-In\n2. Check-Out\n3. Report\n4. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter License Plate: ");
                        string licensePlate = Console.ReadLine();

                        Console.Write("Enter Vehicle Color: ");
                        string color = Console.ReadLine();

                        Console.WriteLine("Enter Vehicle Type (1: Motor, 2: Small Car): ");
                        VehicleType type = Console.ReadLine() == "1" ? VehicleType.Motor : VehicleType.SmallCar;

                        Vehicle vehicle = new Vehicle
                        {
                            LicensePlate = licensePlate,
                            Color = color,
                            Type = type
                        };
                        parkingService.CheckIn(vehicle);
                        break;

                    case "2":
                        Console.Write("Enter License Plate: ");
                        string plate = Console.ReadLine();
                        parkingService.CheckOut(plate);
                        break;

                    case "3":
                        parkingService.GenerateReport();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }
        }
    }
}