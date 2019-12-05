using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Truck : IVehicle
    {
        public int NumberOfAxles { get; }
        public Truck(int numberOfAxles)
        {
            NumberOfAxles = numberOfAxles;  
        }
        public double CalculateToll(int distance)
        {
            double toll = 0.0;
            if (NumberOfAxles == 4)
            {
                toll = distance * 0.040;
            }
            else if (NumberOfAxles == 6)
            {
                toll = distance * 0.045;
            }
            else if (NumberOfAxles >= 8)
            {
                toll = distance * 0.048;
            }
            return toll;
        }
        public override string ToString()
        {
            return "Truck ("+NumberOfAxles+" axels)";
        }
    }
}
