using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class MaxEnd3Tests
    {
        [TestMethod]
        public void MakeArrayTest()
        {
            var exercise = new MaxEnd3();

            //MakeArray([1, 2, 3]) → [3, 3, 3]
            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, exercise.MakeArray(new int[] { 1, 2, 3 }));
            //MakeArray([11, 5, 9]) → [11, 11, 11]
            CollectionAssert.AreEqual(new int[] { 11, 11, 11 }, exercise.MakeArray(new int[] { 11, 5, 9 }));
            //MakeArray([2, 11, 3]) → [3, 3, 3]
            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, exercise.MakeArray(new int[] { 2, 11, 3 }));
        }
    }
}
