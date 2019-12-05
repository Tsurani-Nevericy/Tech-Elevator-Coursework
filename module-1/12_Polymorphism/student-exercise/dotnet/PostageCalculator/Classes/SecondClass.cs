using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SecondClass : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            double result = 0;
            if (weight <= 2.0)
            {
                result = distance * 0.0035;
            }
            else if (weight <= 8)
            {
                result = distance * 0.004;
            }
            else if (weight <= 15)
            {
                result = distance * 0.0047;
            }
            else if (weight <= 16)
            {
                result = distance * 0.0195;
            }
            else if (weight <= 96)
            {
                result = distance * 0.045;
            }
            else
            {
                result = distance * 0.05;
            }
            return result;
        }
        public override string ToString()
        {
            return "Postal Service (2nd Class)";
        }
    }
}
