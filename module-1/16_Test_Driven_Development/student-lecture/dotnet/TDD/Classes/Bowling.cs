using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Classes
{
    public class Bowling
    {
        private const int Spare = 10;
        private const int Strike = 10;

        public int ScoreGame(int[] scores)
        {
            int result = 0;

            // It would be good practice to validate the scores array before continuing
            // and throwing an exception if it is bad data

            var frames = CreateFrames(scores);

            for(int i = 0; i < frames.Count; i++)
            {
                var currentFrame = frames[i];
                if (!currentFrame.IsLastFrame)
                {
                    if (currentFrame.FrameNumber == 9)
                    {
                        result += ScoreFrame(frames[i], frames[i + 1]);
                    }
                    else
                    {
                        result += ScoreFrame(frames[i], frames[i + 1], frames[i + 2]);
                    }
                }
                else
                {
                    result += ScoreFrame(frames[i]);
                }
            }

            return result;
        }

        private int ScoreFrame(Frame currentFrame, Frame nextFrame = null, Frame nexterFrame = null)
        {
            int result = currentFrame.PinCount;

            if (currentFrame.IsSpare && !currentFrame.IsLastFrame)
            {
                result += nextFrame.FirstBall;
            }
            else if (currentFrame.IsSpare)
            {
                result += currentFrame.ThirdBall;
            }
            else if(currentFrame.IsStrike && !currentFrame.IsLastFrame)
            {
                if (nextFrame.IsStrike && nexterFrame != null)
                {
                    result += nextFrame.FirstBall + nexterFrame.FirstBall;
                }
                else
                {
                    result += nextFrame.FirstBall + nextFrame.SecondBall;
                }
            }
            else if (currentFrame.IsStrike)
            {
                result += currentFrame.ThirdBall;
            }

            return result;
        }

        public List<Frame> CreateFrames(int[] scores)
        {
            var result = new List<Frame>();

            int frameCounter = 1;
            for(int i = 0; i < scores.Length; i+=2)
            {
                Frame frame = new Frame();
                frame.FrameNumber = frameCounter;
                frame.FirstBall = scores[i];
                frame.SecondBall = scores[i+1];

                if (frameCounter == 10)
                {
                    frame.ThirdBall = scores[i + 2];
                    i++;
                }
                result.Add(frame);
                frameCounter++;
            }

            return result;
        }
    }
}
