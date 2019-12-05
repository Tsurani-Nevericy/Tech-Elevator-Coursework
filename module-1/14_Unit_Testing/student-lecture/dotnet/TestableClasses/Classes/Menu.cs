using System;
using System.Collections.Generic;
using System.Text;

namespace TestableClasses.Classes
{
    public class Menu
    {
        public void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                // Clear the screen
                Console.Clear();

                // Print menu to screen
                Console.WriteLine("SHIFT 1. Option A");
                Console.WriteLine("2. Option B");
                Console.WriteLine("Q. Quit");

                // Get input from user
                var input = Console.ReadKey();

                // Call corresponding code based on user input
                if (input.Key == ConsoleKey.D1 &&
                    ((input.Modifiers & ConsoleModifiers.Shift) != 0))
                {
                    OptionA();
                }
                else if (input.Key == ConsoleKey.D2)
                {
                    OptionB();
                }
                else if (input.Key == ConsoleKey.Q)
                {
                    exit = true;
                }
            }
        }

        private void OptionA()
        {
            Console.WriteLine("Hi, I'm option A");
            Console.ReadKey();
        }

        private void OptionB()
        {
            Console.WriteLine("Hi, I'm option B");
            Console.ReadKey();
        }
    }
}
