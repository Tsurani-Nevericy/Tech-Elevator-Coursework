using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Person
    {
        public Person(){}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public bool IsAdult()
        {
            bool result = false;
            if (Age >= 18)
            {
                result = true;
            }
            return result;
        }

    }
}
