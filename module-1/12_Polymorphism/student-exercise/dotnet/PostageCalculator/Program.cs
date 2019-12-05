using System;
using System.Collections.Generic;
using System.Globalization;
using PostageCalculator.Classes;

namespace PostageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberFormatInfo format = new NumberFormatInfo();
            bool parseSuccess = false;
            int iPackWeight = 0;
            while (!parseSuccess)
            {
                Console.Write("Please enter the weight of the Package: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out iPackWeight);
            } 

            Console.Write("(P)ounds or (O)unces? ");
            string sIsPOrO = Console.ReadLine().ToLower();
            while (sIsPOrO != "p" && sIsPOrO != "o")
            {
                Console.WriteLine("Please Enter either P or O.");
                sIsPOrO = Console.ReadLine().ToLower();
            }
            
            parseSuccess = false;
            int iDistance = 0;
            while (!parseSuccess)
            {
                Console.Write("What distance will it be traveling? ");
                parseSuccess = int.TryParse(Console.ReadLine(), out iDistance);
            }
            if (sIsPOrO.Equals("p"))
            {
                iPackWeight *= 16;
            }
            List<IDeliveryDriver> drivers = new List<IDeliveryDriver>
            {
                new FirstClass(),
                new SecondClass(),
                new ThirdClass(),
                new FexED(),
                new SPU4D(),
                new SPU2D(),
                new SPUND()
            };
            Console.WriteLine("Delivery Method".PadRight(31) + "$ cost");
            Console.WriteLine("--------------------------------------");

            foreach(IDeliveryDriver driver in drivers)
            {
                Console.WriteLine(driver.ToString().PadRight(31)+"$"+driver.CalculateRate(iDistance, iPackWeight).ToString("N", format));
            }
            Console.ReadKey();
        }
    }
}
