using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class Duck : FarmAnimal
    {

        public Duck() : base("DUCK", 10.00M)
        {
        }

        public override string MakeSoundOnce()
        {
            return "QUACK";
        }

        public override string MakeSoundTwice()
        {
            return "QUACK QUACK";
        }
    }
}
