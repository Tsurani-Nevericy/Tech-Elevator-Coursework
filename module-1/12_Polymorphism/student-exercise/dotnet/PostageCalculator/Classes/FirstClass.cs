using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class FirstClass : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            double result = 0;
            if (weight <= 2.0)
            {
                result = distance * 0.035;
            }
            else if (weight <= 8)
            {
                result = distance * 0.04;
            }
            else if (weight <= 15)
            {
                result = distance * 0.047;
            }
            else if (weight <= 16)
            {
                result = distance * 0.195;
            }
            else if (weight <= 96)
            {
                result = distance * 0.45;
            }
            else
            {
                result = distance * 0.5;
            }
            return result;
        }
        public override string ToString()
        {
            return "Postal Service (1st Class)";
        }
    }
}
