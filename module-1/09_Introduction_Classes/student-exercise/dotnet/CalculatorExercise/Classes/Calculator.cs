using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /// <summary>
    /// Represents a "simple" calculator
    /// </summary>
    public class Calculator
    {
        public Calculator(){}
        public int Result { get; private set; }

        public int Add(int addend)
        {
            Result += addend;
            return Result;
        }
        public int Multiply(int multiplier)
        {
            Result *= multiplier;
            return Result;
        }
        public int Power(int exponent)
        {
            if (exponent < 0)
            {
                exponent = 0-exponent;
            }
            for (int i = 1; i < exponent; i++)
            {
                Result *= Result;
            }
            return Result;
        }
        public int Subtract(int subtrahend)
        {
            Result -= subtrahend;
            return Result;
        }
        public void Reset()
        {
            Result = 0;
        }

    }
}
