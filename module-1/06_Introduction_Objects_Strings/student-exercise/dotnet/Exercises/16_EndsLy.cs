using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return true if it ends in "ly".
         EndsLy("oddly") → true
         EndsLy("y") → false
         EndsLy("oddy") → false
         */
        public bool EndsLy(string str)  
        {
            bool result = false;
            if (str.Length < 2)
            {
                result = false;
            }
            else if (str.Substring(str.Length - 2).Equals("ly"))
            {
                result = true;
            }
            return result;
        }
    }
}
