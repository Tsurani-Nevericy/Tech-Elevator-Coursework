using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class Tractor : ISingable
    {

        public string Name { get; } = "Tractor";


        public string MakeSoundOnce()
        {
            return "VROOM";
        }

        public string MakeSoundTwice()
        {
            return "VROOM VROOM";
        }
    }
}
