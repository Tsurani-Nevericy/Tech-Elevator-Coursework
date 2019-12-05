using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public sealed class Pig : FarmAnimal
    {
        private const string PIG_NOISE = "OINK";
        private const string ANIMAL_TYPE = "PIG";

        public Pig() : base(ANIMAL_TYPE)
        {
        }

        public override string MakeSound()
        {
            return PIG_NOISE;
        }
    }
}
