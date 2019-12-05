using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class SameFirstLastTests
    {
        [TestMethod]
        public void GetHerdTest()
        {
            var exercise = new SameFirstLast();

            //IsItTheSame([1, 2, 3]) → false
            Assert.AreEqual(false, exercise.IsItTheSame(new int[] { 1, 2, 3}));
            //IsItTheSame([1, 2, 3, 1]) → true
            Assert.AreEqual(true, exercise.IsItTheSame(new int[] { 1, 2, 3, 1}));
            //IsItTheSame([1, 2, 1]) → true
            Assert.AreEqual(true, exercise.IsItTheSame(new int[] { 1, 2, 1 }));
        }
    }
}
