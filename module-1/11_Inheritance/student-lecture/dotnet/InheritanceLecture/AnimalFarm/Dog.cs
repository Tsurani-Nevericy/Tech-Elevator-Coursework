using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.AnimalFarm
{
    public class Dog : Animal
    {
        public bool IsMansBestFriend { get; set; }  = true;

        public Dog()
        {
            Sound = "boo";
        }

        public Dog(string sound) : base(sound)
        {

        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("Dog Move");
        }
    }
}
