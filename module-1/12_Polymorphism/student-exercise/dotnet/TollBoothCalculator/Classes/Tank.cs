using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Tank : IVehicle
    {
        public double CalculateToll(int distance)
        {
            return 0.0;
        }
        public override string ToString()
        {
            return "Tank";
        }
    }
}
