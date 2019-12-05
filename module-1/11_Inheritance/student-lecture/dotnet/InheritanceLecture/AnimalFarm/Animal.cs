using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.AnimalFarm
{
    public class Animal
    {
        public string Sound { get; protected set; }

        private bool _canSwim = false;

        public virtual void Move()
        {
            Console.WriteLine("Animal Move");
        }

        public Animal()
        {
        }

        public Animal(string sound)
        {
            Sound = sound;
        }
    }
}
