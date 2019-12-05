using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class Pig : FarmAnimal
    {

        public Pig() : base("PIG", 50.00M)
        {
        }

        public override string MakeSoundOnce()
        {
            return "OINK";
        }

        public override string MakeSoundTwice()
        {
            return "OINK OINK";
        }
    }
}
