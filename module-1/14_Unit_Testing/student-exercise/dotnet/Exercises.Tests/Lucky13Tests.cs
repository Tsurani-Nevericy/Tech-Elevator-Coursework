using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class Lucky13Tests
    {
        [TestMethod]
        public void GetLuckyTest()
        {
            var exercise = new Lucky13();

            //GetLucky([0, 2, 4]) → true
            Assert.AreEqual(true, exercise.GetLucky(new int[] { 0, 2, 4 }));
            //GetLucky([1, 2, 3]) → false
            Assert.AreEqual(false, exercise.GetLucky(new int[] { 1, 2, 3 }));
            //GetLucky([1, 2, 4]) → false
            Assert.AreEqual(false, exercise.GetLucky(new int[] { 1, 2, 4 }));
        }
    }
}
