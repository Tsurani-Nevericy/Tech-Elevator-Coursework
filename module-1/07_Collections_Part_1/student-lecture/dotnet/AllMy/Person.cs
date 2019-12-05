using System;
using System.Collections.Generic;
using System.Text;

namespace AllMyPeople
{
    public class Person
    {
        public int Age {get; set;}

        public void Sneeze()
        {
            Console.WriteLine("Hachew");
        }

        public override bool Equals(object obj)
        {
            return ((Person)obj).Age == Age;
        }
    }
}
