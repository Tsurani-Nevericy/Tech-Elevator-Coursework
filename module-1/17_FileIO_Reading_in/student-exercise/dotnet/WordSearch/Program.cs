using System;
using System.Collections.Generic;
using System.IO;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string startingDirectory = Environment.CurrentDirectory;

            string newPath = @"..\..\..\..\alices_adventures_in_wonderland.txt";
            string oGFileName = @"alices_adventures_in_wonderland.txt";

            string fullPath = Path.Combine(startingDirectory, oGFileName);
            string outputPath = "";

            bool notFinished = true;
            while (notFinished)
            {
                Console.Clear();
                Console.WriteLine("What is fully qualified name of the file that should be searched?");
                newPath = Console.ReadLine();
                if (!File.Exists(newPath))
                {
                    Console.Clear();
                    Console.WriteLine("Input Directory does not exist, invalid source file path.");
                    Console.ReadKey();
                }
                else
                {
                    notFinished = false;
                }
            }

            Console.Clear();
            Console.WriteLine("What is the search word you are looking for?");
            string sSearchPhase = Console.ReadLine();

            Dictionary<int, string> isDict = new Dictionary<int, string>();
            int i = 1;
            using (StreamReader newSR = new StreamReader(newPath))
            {
                while (!newSR.EndOfStream)
                {
                    string sLine = newSR.ReadLine();
                    isDict.Add(i, sLine);
                    i++;
                }
                foreach (int n in isDict.Keys)
                {
                    if (isDict[n].Contains(sSearchPhase))
                    {
                        Console.WriteLine(n+") "+isDict[n]);
                    }
                }
            }
            Console.ReadKey();
        }

    }
}
