using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.AnimalFarm
{
    public class Boxer : Dog
    {
        public bool AreImmuneToConcussions { get; set; } = true;

        public Boxer(string sound) : base(sound)
        {

        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("Boxer Move");
        }
    }
}
