using System;

namespace MessingAround
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            string name = "";
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Say Hello");
                Console.WriteLine("2. Input Name");
                Console.WriteLine("3. Display Name");
                Console.WriteLine("4. Quit");
                Console.WriteLine("Make a selection...");

                char selection = Console.ReadKey().KeyChar;
                if (selection == '1')
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Hello");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (selection == '2')
                {
                    Console.Clear();
                    Console.WriteLine("Enter your name...");
                    name = Console.ReadLine();
                }
                else if (selection == '3')
                {
                    Console.Clear();
                    Console.WriteLine(name);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (selection == '4')
                {
                    exit = true;
                }
            }
        }
    }
}
