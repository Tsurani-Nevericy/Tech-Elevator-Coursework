using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class DateFashionTests
    {
        [TestMethod]
        public void GetATableTest()
        {
            var exercise = new DateFashion();

            //dateFashion(5, 10) → 2
            Assert.AreEqual(2, exercise.GetATable(5, 10));
            //dateFashion(5, 2) → 0
            Assert.AreEqual(0, exercise.GetATable(5, 2));
            //dateFashion(5, 5) → 1
            Assert.AreEqual(1, exercise.GetATable(5, 5));
        }
    }
}
