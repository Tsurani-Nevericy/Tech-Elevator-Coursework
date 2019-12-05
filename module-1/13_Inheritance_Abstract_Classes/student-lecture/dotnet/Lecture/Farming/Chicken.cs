using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal
    {
        private const string CHICKEN_NOISE = "CLUCK";
        private const string ANIMAL_TYPE = "CHICKEN";

        /// <summary>
        /// Creates a new horse.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Chicken() : base(ANIMAL_TYPE)
        {
        }

        /// <summary>
        /// The single noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSound()
        {
            return CHICKEN_NOISE;
        }

    }
}
