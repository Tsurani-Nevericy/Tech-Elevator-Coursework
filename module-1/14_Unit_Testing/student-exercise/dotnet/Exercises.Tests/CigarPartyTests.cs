using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class CigarPartyTests
    {
        [TestMethod]
        public void HavePartyTest()
        {
            var exercise = new CigarParty();
            
            //haveParty(30, false) → false
            Assert.AreEqual(false, exercise.HaveParty(30, false));
            //haveParty(50, false) → true
            Assert.AreEqual(true, exercise.HaveParty(50, false));
            //haveParty(70, true) → true
            Assert.AreEqual(true, exercise.HaveParty(70, true));
        }
    }
}
