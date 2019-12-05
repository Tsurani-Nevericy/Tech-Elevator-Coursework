using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()

        [TestMethod]
        public void TestSomething()
        {
            Assert.Fail("Hey Bill, I failed again :(");
        }


        [TestMethod]
        public void MakeAbbaTest()
        {
            //makeAbba("Hi", "Bye") → "HiByeByeHi"
            //makeAbba("Yo", "Alice") → "YoAliceAliceYo"
            //makeAbba("What", "Up") → "WhatUpUpWhat"

            // Arrange
            var obj = new StringExercises();

            // Act
            var result = obj.MakeAbba("Hi", "Bye");

            // These are various possible edge cases for the method MakeAbba
            //obj.MakeAbba("", "Bye");
            //obj.MakeAbba("Hi", "");
            //obj.MakeAbba("", "");
            //obj.MakeAbba(null,"");
            //obj.MakeAbba(null, null);
            //obj.MakeAbba("", null);

            // Assert
            Assert.AreEqual("HiByeByeHi", result, "Was expecting ABBA format.");

            // Act
            result = obj.MakeAbba("Yo", "Alice");

            // Assert
            Assert.AreEqual("YoAliceAliceYo", result, "Was expecting ABBA format.");

            // Act
            result = obj.MakeAbba("What", "Up");

            // Assert
            Assert.AreEqual("WhatUpUpWhat", result, "Was expecting ABBA format.");

            //Assert.AreEqual("HiByeByeHi", obj.MakeAbba("Hi", "Bye"), "Was expecting ABBA format.");
            //Assert.AreEqual("YoAliceAliceYo", obj.MakeAbba("Yo", "Alice"), "Was expecting ABBA format.");
            //Assert.AreEqual("WhatUpUpWhat", obj.MakeAbba("What", "Up"), "Was expecting ABBA format.");

        }
                     
    }
}