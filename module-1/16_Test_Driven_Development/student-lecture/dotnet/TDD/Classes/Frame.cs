using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Classes
{
    public class Frame
    {
        private const int LastFrame = 10;
        private const int AllPins = 10;

        public int FrameNumber { get; set; } = 0;
        public int FirstBall { get; set; } = 0;
        public int SecondBall { get; set; } = 0;
        public int ThirdBall { get; set; } = 0;

        public int PinCount
        {
            get
            {
                return FirstBall + SecondBall;
            }
        }

        public bool IsLastFrame
        {
            get
            {
                return FrameNumber == LastFrame ? true : false;
            }
        }

        public bool IsStrike
        {
            get
            {
                return FirstBall == AllPins;
            }
        }

        public bool IsSpare
        {
            get
            {
                return !IsStrike && PinCount == AllPins;
            }
        }
    }
}
