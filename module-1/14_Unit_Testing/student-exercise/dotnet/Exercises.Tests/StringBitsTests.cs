using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class StringBitsTests
    {
        [TestMethod]
        public void GetBitsTest()
        {
            var exercise = new StringBits();

            //GetBits("Hello") → "Hlo"
            Assert.AreEqual("Hlo", exercise.GetBits("Hello"));
            //GetBits("Hi") → "H"
            Assert.AreEqual("H", exercise.GetBits("Hi"));
            //GetBits("Heeololeo") → "Hello"
            Assert.AreEqual("Hello", exercise.GetBits("Heeololeo"));
        }
    }
}
