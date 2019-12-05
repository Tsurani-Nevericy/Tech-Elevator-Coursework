using System;
using System.Collections.Generic;
using System.IO;

namespace file_io_part1_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Ask the user for the search string
            //2. Ask the user for the file path
            //3. Open the file
            //4. Loop through each line in the file
            //5. If the line contains the search string, print it out along with its line number

            string oGFilePath = @"..\..\..\..";
            string oGFileName = "sample-quiz-file.txt";

            List<Quiz> lqQuiz = new List<Quiz>();

            string fullPath = Path.Combine(oGFilePath, oGFileName);
            
            int nCorrectAnswers = 0;
            int nTotalAnswers = 0;
            using (StreamReader newSR = new StreamReader(fullPath))
            {
                while (!newSR.EndOfStream)
                {
                    string sLine = newSR.ReadLine();

                    Quiz qQuiz = new Quiz(sLine);

                    Console.WriteLine(qQuiz.sPrompt);
                    Console.WriteLine("1. " + qQuiz.sOption1);
                    Console.WriteLine("2. " + qQuiz.sOption2);
                    Console.WriteLine("3. " + qQuiz.sOption3);
                    Console.WriteLine("4. " + qQuiz.sOption4);

                    Console.Write("\nYour answer: ");
                    string sAnswer = Console.ReadLine();

                    int iUserAnswer = int.Parse(sAnswer);

                    if (iUserAnswer == qQuiz.nCorrectAnswer)
                    {
                        Console.WriteLine("RIGHT!\n");
                        nCorrectAnswers++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG!\n");
                    }
                    nTotalAnswers++;
                }
            }
            Console.WriteLine("You got "+nCorrectAnswers+" answer(s) correct out of the "+nTotalAnswers+" questions asked.");
            Console.ReadKey();
        }
    }
}
