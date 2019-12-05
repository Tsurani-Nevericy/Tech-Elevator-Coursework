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
         Given two lists of Integers, interleave them beginning with the first element in the first list followed
         by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
         Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
         list to the new list before returning it.
		 DIFFICULTY: HARD
         InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
         */
        public List<int> InterleaveLists(List<int> listOne, List<int> listTwo)
        {
            List<int> liNewList = new List<int>();
            int iMost = listTwo.Count;
            int n = 0;
            if (listOne.Count >= listTwo.Count)
            {
                iMost = listOne.Count;
            }
            while (n < iMost)
            {
                if (n < listOne.Count)
                liNewList.Add(listOne.ElementAt(n));
                if (n < listTwo.Count)
                liNewList.Add(listTwo.ElementAt(n));
                n++;
            }
            return liNewList;
        }
    }
}
