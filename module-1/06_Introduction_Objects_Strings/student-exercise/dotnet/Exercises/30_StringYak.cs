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
         Suppose the string "yak" is unlucky. Given a string, return a version where all the "yak" are removed, but
         the "a" can be any char. The "yak" strings will not overlap.
         StringYak("yakpak") → "pak"
         StringYak("pakyak") → "pak"
         StringYak("yak123ya") → "123ya"
         */
        public string StringYak(string str)
        {
            string sNew = "";
            if (str.Length < 3)
            {
                return str;
            }
            for (int i = 0; i < str.Length-2; i++)
            {
                if (str.Substring(i, 3) == "yak")
                {
                    i += 2;
                }
                else
                {
                    sNew += str.Substring(i, 1);
                }
            }
            if (str.Substring(str.Length - 3, 3) != "yak")
            {
                sNew += str.Substring(str.Length-2,2);
            }
            return sNew;
        }
    }
}
