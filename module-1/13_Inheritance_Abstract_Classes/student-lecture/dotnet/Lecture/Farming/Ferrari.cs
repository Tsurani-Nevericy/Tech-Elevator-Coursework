using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Ferrari : ISound
    {
        private const string FERRARI_NOISE = "Vrooom";

        public string MakeSound()
        {
            return FERRARI_NOISE;
        }
    }
}
