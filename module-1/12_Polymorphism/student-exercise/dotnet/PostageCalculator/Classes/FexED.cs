using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class FexED : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            double rate = 20.0;
            if (distance > 500)
            {
                rate += 5;
            }
            if (weight > 48)
            {
                rate += 3;
            }
            return rate;
        }
        public override string ToString()
        {
            return "FedEX";
        }
    }
}
