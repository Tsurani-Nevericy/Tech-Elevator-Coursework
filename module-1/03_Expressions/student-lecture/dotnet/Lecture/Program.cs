using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (IsGreaterThanFive(6))
            {
                if(IsGreaterThanFive(4))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool IsGreaterThanFive(int number)
        {
            return number > 5;
        }
    }
}
