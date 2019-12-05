using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class ThirdClass : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            double result = 0;
            if (weight <= 2.0)
            {
                result = distance * 0.002;
            }
            else if (weight <= 8)
            {
                result = distance * 0.0022;
            }
            else if (weight <= 15)
            {
                result = distance * 0.0024;
            }
            else if (weight <= 16)
            {
                result = distance * 0.015;
            }
            else if (weight <= 96)
            {
                result = distance * 0.016;
            }
            else
            {
                result = distance * 0.017;
            }
            return result;
        }
        public override string ToString()
        {
            return "Postal Service (3rd Class)";
        }
    }
}
