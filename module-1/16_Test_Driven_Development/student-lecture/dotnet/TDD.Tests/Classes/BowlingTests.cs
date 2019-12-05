using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TDD.Classes;

namespace TDD.Tests
{
    [TestClass]
    public class BowlingTests
    {
        private Bowling _bowling = new Bowling();

        // All Frames Gutter Ball
        [TestMethod]
        public void AllFramesGutterBall()
        {
            int[] scores = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Assert.AreEqual(0, _bowling.ScoreGame(scores), "All frames were gutter balls.");
        }

        // All Frames One Pin
        [TestMethod]
        public void AllFramesOnePin()
        {
            int[] scores = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0 };
            Assert.AreEqual(10, _bowling.ScoreGame(scores), "All frames with one pint.");
        }

        // One Spare
        [TestMethod]
        public void OneSpare()
        {
            int[] scores = { 1, 9, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 9, 5 };
            Assert.AreEqual(34, _bowling.ScoreGame(scores), "One spare.");
        }

        // One Strike
        [TestMethod]
        public void OneStrike()
        {
            int[] scores = { 10, 2, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 0, 10 };
            Assert.AreEqual(41, _bowling.ScoreGame(scores), "One strike.");
        }

        // Two Consecutive Strikes
        [TestMethod]
        public void TwoConsecutiveStrikes()
        {
            int[] scores = { 10, 0, 10, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 0, 1, 0, 0 };
            Assert.AreEqual(50, _bowling.ScoreGame(scores), "Two consecutive strikes.");
        }

        // Tenth Frame Strike/Spare
        [TestMethod]
        public void TenthFrameStrikeSpare()
        {
            int[] scores = { 10, 0, 10, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 0, 10, 5, 5 };
            Assert.AreEqual(83, _bowling.ScoreGame(scores), "Tenth frame strike and spare.");
        }

        // Tenth Frame Strike/Strike
        [TestMethod]
        public void TenthFrameStrikeStrike()
        {
            int[] scores = { 10, 0, 10, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 0, 10, 10, 5 };
            Assert.AreEqual(93, _bowling.ScoreGame(scores), "Tenth frame strike and strike.");
        }

        // Perfect Game  
        [TestMethod]
        public void PerfectGame()
        {
            int[] scores = { 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 10, 10 };
            Assert.AreEqual(300, _bowling.ScoreGame(scores), "Perfect game.");
        }

        [TestMethod]
        public void CreateFramesTest()
        {
            int[] scores = { 1, 9, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 9, 8 };
            var frames = _bowling.CreateFrames(scores);
            Assert.AreEqual(10, frames.Count);
            Assert.AreEqual(1, frames[0].FirstBall);
            Assert.AreEqual(1, frames[9].FirstBall);
            Assert.AreEqual(9, frames[0].SecondBall);
            Assert.AreEqual(8, frames[9].ThirdBall);
        }

        [TestMethod]
        public void FramesSpareTest()
        {
            Frame frame = new Frame();
            frame.FrameNumber = 1;

            frame.FirstBall = 5;
            Assert.IsFalse(frame.IsSpare);

            frame.SecondBall = 3;
            Assert.IsFalse(frame.IsSpare);

            frame.FirstBall = 10;
            Assert.IsFalse(frame.IsSpare);

            frame.FirstBall = 5;
            frame.SecondBall = 5;
            Assert.IsTrue(frame.IsSpare);

            frame.FirstBall = 0;
            frame.SecondBall = 10;
            Assert.IsTrue(frame.IsSpare);
        }

        [TestMethod]
        public void FramesStrikeTest()
        {
            Frame frame = new Frame();
            frame.FrameNumber = 1;

            frame.FirstBall = 5;
            Assert.IsFalse(frame.IsStrike);

            frame.FirstBall = 10;
            Assert.IsTrue(frame.IsStrike);
        }
    }
}
