using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    interface ISellable
    {
        decimal Price { get; }

        string Sell();
    }
}
