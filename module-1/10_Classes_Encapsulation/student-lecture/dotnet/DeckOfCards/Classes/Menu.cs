using System;
using System.Collections.Generic;
using System.Text;

namespace YummyStuff
{
    public class Menu
    {
        private FoodMenu _foodMenu = null;

        public Menu(FoodMenu foodMenu)
        {
            _foodMenu = foodMenu;
        }

        public void MainMenu()
        {
            bool exit = false;
            while(!exit)
            {
                // Display menu to user
                Console.Clear();
                Console.WriteLine("1. Add Entree");
                Console.WriteLine("2. Display Menu");
                Console.WriteLine("3. Quit");

                // Get user input
                char selection = Console.ReadKey().KeyChar;

                // Run code based on input
                if(selection == '1')
                {
                    AddEntree();
                }
                else if(selection == '2')
                {
                    Console.Clear();
                    Console.WriteLine(_foodMenu.PrintMenu());
                    Console.ReadKey();
                }
                else if(selection == '3')
                {
                    // Quit
                    exit = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid selection, press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        private void AddEntree()
        {
            Console.Clear();
            Console.Write("Enter the entree title: ");
            string title = Console.ReadLine();

            Console.Write("Enter the entree description: ");
            string description = Console.ReadLine();

            Console.Write("Enter the entree price: ");
            string priceStr = Console.ReadLine();
            decimal price = decimal.Parse(priceStr);

            _foodMenu.AddEntree(title, description, price);
        }
    }
}
