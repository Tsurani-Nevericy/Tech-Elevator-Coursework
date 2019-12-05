using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SPUND : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            return (weight * 0.0046875) * distance;
        }
        public override string ToString()
        {
            return "SPU (Next Day)";
        }
    }
}
