using System;
using System.IO;

namespace FizzWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string startingDirectory = Environment.CurrentDirectory;
            string outputPath = @"..\..\..\..\FizzBuzz.txt";
            
            using (StreamWriter newSW = new StreamWriter(outputPath, false))
            {
                for (int i = 1; i <= 300; i++)
                {
                    if ((i % 3 == 0 || i.ToString().Contains("3")) && i % 5 != 0)
                    {
                        newSW.WriteLine("Fizz");
                    }
                    else if ((i % 5 == 0 || i.ToString().Contains("5")) && i % 3 != 0)
                    {
                        newSW.WriteLine("Buzz");
                    }
                    else if (i % 3 == 0 && i % 5 == 0)
                    {
                        newSW.WriteLine("FizzBuzz");
                    }
                    else
                    {
                        newSW.WriteLine(i);
                    }
                }
            }
        }
    }
}
