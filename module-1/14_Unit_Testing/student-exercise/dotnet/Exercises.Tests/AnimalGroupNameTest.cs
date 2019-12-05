using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Exercises;

namespace Exercises.Tests
{
    [TestClass()]
    public class AnimalGroupNameTests
    {
        [TestMethod]
        public void GetHerdTest()
        {
            var exercise = new AnimalGroupName();

            //GetHerd("giraffe") → "Tower"
            Assert.AreEqual("Tower", exercise.GetHerd("giraffe"));
            //GetHerd("")-> "unknown"
            Assert.AreEqual("unknown", exercise.GetHerd(""));
            //GetHerd("walrus")-> "unknown"
            Assert.AreEqual("unknown", exercise.GetHerd("walrus"));
            //GetHerd("Rhino")-> "Crash"
            Assert.AreEqual("Crash", exercise.GetHerd("Rhino"));
            //GetHerd("rhino")-> "Crash"
            Assert.AreEqual("Crash", exercise.GetHerd("rhino"));
            //GetHerd("elephants")-> "unknown"
            Assert.AreEqual("unknown", exercise.GetHerd("elephants"));
        }
    }
}
