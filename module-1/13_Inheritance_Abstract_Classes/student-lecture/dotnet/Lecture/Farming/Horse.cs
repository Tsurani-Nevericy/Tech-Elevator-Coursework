using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Horse : FarmAnimal
    {
        private const string HORSE_NOISE = "NEIGH";
        private const string ANIMAL_TYPE = "HORSE";

        /// <summary>
        /// Creates a new horse.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Horse() : base(ANIMAL_TYPE)
        {
        }

        /// <summary>
        /// The single noise the horse makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSound()
        {
            return HORSE_NOISE;
        }

        public void Gallup()
        {

        }
    }
}
