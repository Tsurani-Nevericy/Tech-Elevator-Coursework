using System;
using System.Collections.Generic;
using System.Text;

namespace file_io_part1_exercises
{
    public class Quiz
    {
        public Quiz(string sLine)
        {
            NewQuestion(sLine);
        }

        public string sPrompt { get; set; }
        public string sOption1 { get; set; }
        public string sOption2 { get; set; }
        public string sOption3 { get; set; }
        public string sOption4 { get; set; }
        public int nCorrectAnswer { get; set; }

        public void NewQuestion(string sLine)
        {
            string[] sLines = sLine.Split('|', StringSplitOptions.RemoveEmptyEntries);
            sPrompt = sLines[0];

            sOption1 = sLines[1];
            sOption2 = sLines[2];
            sOption3 = sLines[3];
            sOption4 = sLines[4];

            if (sOption1.Contains("*"))
            {
                sOption1 = sOption1.Replace("*", "");
                nCorrectAnswer = 1;
            }
            else if (sOption2.Contains("*"))
            {
                sOption2 = sOption2.Replace("*", "");
                nCorrectAnswer = 2;
            }
            else if (sOption3.Contains("*"))
            {
                sOption3 = sOption3.Replace("*", "");
                nCorrectAnswer = 3;
            }
            else if (sOption4.Contains("*"))
            {
                sOption4 = sOption4.Replace("*", "");
                nCorrectAnswer = 4;
            }
        }

    }
}
