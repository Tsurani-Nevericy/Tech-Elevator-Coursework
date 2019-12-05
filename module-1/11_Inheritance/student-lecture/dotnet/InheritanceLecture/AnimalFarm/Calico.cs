using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.AnimalFarm
{
    public class Calico : Cat
    {
        public bool AreAllFemale {get; set;} = true;

        public Calico(string sound) : base(sound)
        {
        }
    }
}
