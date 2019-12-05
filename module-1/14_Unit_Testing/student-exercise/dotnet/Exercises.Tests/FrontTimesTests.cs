using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class FrontTimesTests
    {
        [TestMethod]
        public void GenerateStringTest()
        {
            var exercise = new FrontTimes();

            //frontTimes("Chocolate", 2) → "ChoCho"
            Assert.AreEqual("ChoCho", exercise.GenerateString("Chocolate", 2));
            //frontTimes("Chocolate", 3) → "ChoChoCho"
            Assert.AreEqual("ChoChoCho", exercise.GenerateString("Chocolate", 3));
            //frontTimes("Abc", 3) → "AbcAbcAbc"
            Assert.AreEqual("AbcAbcAbc", exercise.GenerateString("Abc", 3));
        }
    }
}
