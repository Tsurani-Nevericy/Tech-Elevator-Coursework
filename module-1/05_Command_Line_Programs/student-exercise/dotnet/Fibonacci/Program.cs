using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the Fibonacci Number:");
            string sInput = Console.ReadLine();
            int nInput = int.Parse(sInput);
            string sLine = "";
            int nSum = 0;
            int nFirst = 0;
            int nSecond = 1;
            while (nInput > nFirst)
            {
                sLine += nFirst+", ";
                //Console.WriteLine(nFirst);
                nSum = nFirst + nSecond;
                nFirst = nSecond;
                nSecond = nSum;
            }
            sLine = sLine.Substring(0, sLine.Length - 2);
            Console.WriteLine(sLine);
            Console.ReadKey();
        }
    }
}
