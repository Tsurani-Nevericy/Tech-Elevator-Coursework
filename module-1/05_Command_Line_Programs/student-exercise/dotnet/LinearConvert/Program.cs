using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the Length: ");
            string sLengthInput = Console.ReadLine();
            string newString = sLengthInput.Substring(0, sLengthInput.Length - 1);
            int nLengthInput = int.Parse(newString);
            float fLengthInput = nLengthInput;
            float fLengthOutput = 0.0f;
            string sLine = "";
            if (sLengthInput.Substring(sLengthInput.Length - 1) == "f" || sLengthInput.Substring(sLengthInput.Length - 1) == "F")
            {
                fLengthOutput = fLengthInput * 0.3048f;
                sLine = fLengthInput + "f is " + (int)fLengthOutput + "m";
            }
            else if (sLengthInput.Substring(sLengthInput.Length - 1) == "m" || sLengthInput.Substring(sLengthInput.Length - 1) == "M")
            {
                fLengthOutput = fLengthInput * 3.2808399f;
                sLine = fLengthInput + "m is " + (int)fLengthOutput + "f";
            }
            Console.WriteLine(sLine);
            Console.ReadKey();
        }
    }
}
