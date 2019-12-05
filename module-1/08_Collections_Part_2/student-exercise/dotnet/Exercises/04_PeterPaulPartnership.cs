using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Modify and return the given Dictionary as follows: if "Peter" has $50 or more, AND "Paul" has $100 or more,
         * then create a new "PeterPaulPartnership" worth a combined contribution of a quarter of each partner's
         * current worth.
         *
         * Note, monetary amounts are specified in cents: penny=1, nickel=5, ... $1=100, ... $10=1000, ...
         * 
         * PeterPaulPartnership({"Peter": 50000, "Paul": 100000}) → {"Peter": 37500, "Paul": 75000, "PeterPaulPartnership": 37500}
         * PeterPaulPartnership({"Peter": 3333, "Paul": 1234567890}) → {"Peter": 3333, "Paul": 1234567890}
         *
         */
        public Dictionary<string, int> PeterPaulPartnership(Dictionary<string, int> peterPaul)
        {
            int i = 0;
            if (peterPaul["Peter"] >= 5000 && peterPaul["Paul"] >= 10000)
            {
                i = peterPaul["Peter"]/4 + peterPaul["Paul"]/4;
                peterPaul["Peter"] = peterPaul["Peter"] * 3 / 4;
                peterPaul["Paul"] = peterPaul["Paul"] * 3 / 4;
                peterPaul.Add("PeterPaulPartnership", i);
            }
            return peterPaul;
        }
    }
}
