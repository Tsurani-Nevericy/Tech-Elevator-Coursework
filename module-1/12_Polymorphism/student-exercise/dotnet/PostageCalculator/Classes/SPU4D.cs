using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SPU4D : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            return (weight * 0.0003125) * distance;
        }
        public override string ToString()
        {
            return "SPU (4-Day Ground)";
        }
    }
}
