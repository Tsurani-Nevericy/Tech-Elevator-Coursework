using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Car : IVehicle
    {
        public bool HasTrailer { get; }
        public Car(bool hasTrailer)
        {
            HasTrailer = hasTrailer;
        }
        public double CalculateToll(int distance)
        {
            double toll = distance * 0.020;
            if (HasTrailer)
            {
                toll += 1.00;
            }
            return toll;
        }
        public override string ToString()
        {
            string addOn = "";
            if (HasTrailer)
            {
                addOn = " (with Trailer)";
            }
            return "Car"+addOn;
        }
    }
}
