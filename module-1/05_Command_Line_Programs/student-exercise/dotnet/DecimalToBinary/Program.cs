using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in a series of decimal values (separated by spaces):");
            string sInput = Console.ReadLine();
            string[] aNumbers = sInput.Split();
            string sNumber = "";

            for (int i = 0; i < aNumbers.Length; i++)
            {
                sNumber = "";
                int nInput = int.Parse(aNumbers[i]);
                int nStored = int.Parse(aNumbers[i]);
                while (nInput >= 1)
                {
                    sNumber = nInput % 2 + sNumber;
                   
                    nInput /= 2;
                }
                Console.WriteLine(nStored+" in binary is "+sNumber+".");
            }
            Console.ReadKey();
        }
    }
}