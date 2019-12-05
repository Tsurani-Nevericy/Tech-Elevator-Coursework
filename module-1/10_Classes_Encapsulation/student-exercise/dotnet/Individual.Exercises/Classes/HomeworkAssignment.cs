using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }
        public int PossibleMarks { get; }
        public string SubmitterName { get; }
        public string LetterGrade
        {
            get
            {
                string sResult = "F";
                double dResult = EarnedMarks / (double)PossibleMarks * 100.0;
                if (dResult >= 90)
                {
                    sResult = "A";
                }
                else if (dResult >= 80)
                {
                    sResult = "B";
                }
                else if (dResult >= 70)
                {
                    sResult = "C";
                }
                else if (dResult >= 60)
                {
                    sResult = "D";
                }
                return sResult;
            }
        }

        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            PossibleMarks = possibleMarks;
            SubmitterName = submitterName;
        }



    }
}
