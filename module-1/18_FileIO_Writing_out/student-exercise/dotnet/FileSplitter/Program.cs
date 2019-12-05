using System;
using System.IO;

namespace FileSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Where is the input file (please include the path to the file)? ");
            string sPath = Console.ReadLine();
            string[] sPathSections = sPath.Split('\\');
            string sDirectoryPath = "";
            foreach (string ss in sPathSections)
            {
                if (sPathSections[sPathSections.Length-1] != ss)
                {
                    sDirectoryPath += ss+"\\";
                }
            }
            string fileName = sPathSections[sPathSections.Length - 1];
            fileName = fileName.Substring(0, fileName.Length - 4);
            Console.Write("\nHow many lines of text (max) should there be in the split files? ");
            string sMaxLinesPer = Console.ReadLine();
            int i = int.Parse(sMaxLinesPer);
            Console.WriteLine("**GENERATING OUTPUT**");
            int iFileVersion = 1;
            string s = iFileVersion.ToString();
            using (StreamReader newSR = new StreamReader(sPath))
            {
                while (!newSR.EndOfStream)
                {
                    using (StreamWriter newSW = new StreamWriter(sDirectoryPath+fileName+"-"+s+".txt", false))
                    {
                        for (int n = 0; n < i; n++)
                        {
                            newSW.WriteLine(newSR.ReadLine());
                        }
                        iFileVersion++;
                        s = iFileVersion.ToString();
                    }
                }
            }
        }
    }
}
