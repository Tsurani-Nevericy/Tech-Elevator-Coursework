using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SPU2D : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            return (weight * 0.003125) * distance;
        }
        public override string ToString()
        {
            return "SPU (2-Day Business)";
        }
    }
}
