using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {
        /*
        16. Return "Big Even Number" when number is even, larger than 100, and a multiple of 5.
            Return "Big Number" if the number is just larger than 100.
            Return empty string for everything else.
            TOPIC: Complex Expression
        */
        public string ReturnBigEvenNumber(int number)
        {
            string result = "";

            bool isEven = number % 2 == 0;
            bool isLargerThan100 = number > 100;
            bool isMultipleOf5 = number % 5 == 0;

            // if number is even and the number is larger than 100 and it is a multiple 5
            if (isEven && isLargerThan100 && isMultipleOf5)
            {
                // set result to "Big Even Number"
                result = "Big Even Number";
            }
            // else if number is larger than 100
            else if (isLargerThan100)
            {
                // set result to "Big Number"
                result = "Big Number";
            }

            return result;
        }

        //public string ReturnBigEvenNumber(int number)
        //{
        //    if (number % 2 == 0 && number > 100 && number % 5 == 0)
        //    {
        //        return "Big Even Number";
        //    }
        //    else if (number > 100)
        //    {
        //        return "Big Number";
        //    }

        //    return "";
        //}



    }
}
