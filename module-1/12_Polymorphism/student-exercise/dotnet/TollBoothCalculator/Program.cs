using System;
using System.Collections.Generic;
using TollBoothCalculator.Classes;
using System.Globalization;

namespace TollBoothCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();
            Random rand = new Random();
            NumberFormatInfo format = new NumberFormatInfo();
            
            vehicles.Add(new Car(false));
            vehicles.Add(new Car(true));
            vehicles.Add(new Tank());
            vehicles.Add(new Truck(4));
            vehicles.Add(new Truck(6));
            vehicles.Add(new Truck(8));
            int nDistance = 0;
            int nTotalDist = 0;
            double nToll = 0.0;
            double nTotalToll = 0.0;
            Console.WriteLine("Vehicle".PadRight(19)+"Distance Traveled".PadRight(23)+"Toll $");
            Console.WriteLine("-------------------------------------------------");
            foreach (IVehicle vehicle in vehicles)                             
            {
                nDistance = rand.Next(10, 240);
                nToll = vehicle.CalculateToll(nDistance);
                nTotalDist += nDistance;
                nTotalToll += nToll;

                Console.WriteLine(vehicle.ToString().PadRight(19)+nDistance.ToString().PadRight(23)+nToll.ToString("N", format));
            }
            Console.WriteLine($"\nTotal Miles Travelled: {nTotalDist}");
            Console.WriteLine($"Total Tollbooth Revenue: ${nTotalToll}");
            Console.ReadKey();
        }
    }
}
