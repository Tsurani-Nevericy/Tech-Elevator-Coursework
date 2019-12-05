using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the Temperature: ");
            string sTempInput = Console.ReadLine();
            string newString = sTempInput.Substring(0, sTempInput.Length-1);
            int nTempInput = int.Parse(newString);
            float fTempInput = nTempInput;
            float fTempOutput = 0.0f;
            string sLine = "";
            if (sTempInput.Substring(sTempInput.Length-1) == "f" || sTempInput.Substring(sTempInput.Length - 1) == "F")
            {
                fTempOutput = (fTempInput - 32.0f) / 1.8f;
                sLine = fTempInput + "F is " + (int)fTempOutput+"C";
            }
            else if (sTempInput.Substring(sTempInput.Length - 1) == "c" || sTempInput.Substring(sTempInput.Length - 1) == "C")
            {
                fTempOutput = fTempInput * 1.8f + 32.0f;
                sLine = fTempInput + "C is " + (int)fTempOutput + "F";
            }
            Console.WriteLine(sLine);
            Console.ReadKey();
        }
    }
}
