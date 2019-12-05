using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class Apple : ISellable
    {
        public decimal Price { get; } = 1.00M;

        public string Sell()
        {
            return "You sold the apple!";
        }
    }
}
