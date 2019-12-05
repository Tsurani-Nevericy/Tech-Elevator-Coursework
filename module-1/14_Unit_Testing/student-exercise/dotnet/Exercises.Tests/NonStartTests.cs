using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class NonStartTests
    {
        [TestMethod]
        public void GetPartialStringTest()
        {
            var exercise = new NonStart();

            //GetPartialString("Hello", "There") → "ellohere"
            Assert.AreEqual("ellohere", exercise.GetPartialString("Hello", "There"));
            //GetPartialString("java", "code") → "avaode"
            Assert.AreEqual("avaode", exercise.GetPartialString("java", "code"));
            //GetPartialString("shotl", "java") → "hotlava"
            Assert.AreEqual("hotlava", exercise.GetPartialString("shotl", "java"));
        }
    }
}
