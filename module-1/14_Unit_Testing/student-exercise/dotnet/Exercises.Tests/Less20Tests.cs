using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class Less20Tests
    {
        [TestMethod]
        public void IsLessThanMultipleOf20Test()
        {
            var exercise = new Less20();

            //less20(18) → true
            Assert.AreEqual(true, exercise.IsLessThanMultipleOf20(18));
            //less20(19) → true
            Assert.AreEqual(true, exercise.IsLessThanMultipleOf20(19));
            //less20(20) → false
            Assert.AreEqual(false, exercise.IsLessThanMultipleOf20(20));
        }
    }
}
