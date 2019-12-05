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
         Given an array of ints, return true if the array contains a 2 next to a 2 somewhere.
         Has22([1, 2, 2]) → true
         Has22([1, 2, 1, 2]) → false
         Has22([2, 1, 2]) → false
         */
        public bool Has22(int[] nums)
        {
            bool result = false;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 && nums[i] == nums[i + 1] && nums[i] == 2)
                {
                    result = true;
                }
                else if (i == nums.Length-1 && nums[i] == nums[i - 1] && nums[i] == 2)
                {
                    result = true;
                }
                else if (i != 0 && i != nums.Length-1 && (nums[i] == nums[i + 1] || nums[i] == nums[i - 1]) && nums[i] == 2) 
                {
                    result = true;
                }
            }
            return result;
        }

    }
}
