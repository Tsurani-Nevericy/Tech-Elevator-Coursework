using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator
{
    interface IVehicle
    {
        double CalculateToll(int distance);
    }
}
