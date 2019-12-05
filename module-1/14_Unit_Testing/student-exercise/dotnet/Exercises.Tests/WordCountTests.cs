using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass()]
    public class WordCountTests
    {
        [TestMethod]
        public void GetCountTest()
        {
            var exercise = new WordCount();

            //GetCount(["ba", "ba", "black", "sheep"]) → { "ba" : 2, "black": 1, "sheep": 1 }
            CollectionAssert.AreEquivalent(
                new Dictionary<string, int>
                {
                    { "ba", 2 },
                    { "black", 1},
                    { "sheep", 1 }
                }, exercise.GetCount(
                    new string[] 
                    { "ba", "ba", "black", "sheep" }
                )
            );
            //GetCount(["a", "b", "a", "c", "b"]) → { "b": 2, "c": 1, "a": 2}
            CollectionAssert.AreEquivalent(
                new Dictionary<string, int>
                {
                    { "b", 2 },
                    { "c", 1},
                    { "a", 2 }
                }, exercise.GetCount(
                    new string[]
                    { "a", "b", "a", "c", "b" }
                )
            );
            //GetCount([]) → { }
            CollectionAssert.AreEquivalent(
                new Dictionary<string, int>
                {

                }, exercise.GetCount(
                    new string[]
                    { }
                )
            );
            //GetCount(["c", "b", "a"]) → { "b": 1, "c": 1, "a": 1}
            CollectionAssert.AreEquivalent(
                new Dictionary<string, int>
                {
                    { "b", 1 },
                    { "c", 1},
                    { "a", 1 }
                }, exercise.GetCount(
                    new string[]
                    { "c", "b", "a" }
                )
            );
        }
    }
}
