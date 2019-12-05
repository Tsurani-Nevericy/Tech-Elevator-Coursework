using System;
using System.Collections.Generic;
using System.Text;
using WizardWardrobe;

namespace WizardWardrobeCLI
{
    public class Menu
    {
        private Wardrobe _wardrobe = null;

        public Menu(Wardrobe wardrobe)
        {
            _wardrobe = wardrobe;
        }

        public void MainMenu()
        {
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Display Costume List");
                Console.WriteLine("2. Display Costume Details");
                Console.WriteLine("Q. Exit");
                Console.WriteLine();
                Console.WriteLine("Make Selection...");

                var keySelection = Console.ReadKey();

                if(keySelection.Key == ConsoleKey.D1)
                {
                    HandleCostumeList();
                }
                else if (keySelection.Key == ConsoleKey.D2)
                {
                    HandleCostumeDetails();
                }
                else if (keySelection.Key == ConsoleKey.Q)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection, press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private void HandleCostumeList()
        {
            Console.Clear();
            DisplayCostumeList();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplayCostumeList()
        {
            int index = 1;
            foreach (var costume in _wardrobe.Costumes)
            {
                Console.WriteLine($"{index++}. {costume.Name}");
            }
        }

        private void HandleCostumeDetails()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                DisplayCostumeList();
                Console.WriteLine("Q. Previous Menu");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Make Selection...");

                var keySelection = Console.ReadLine();

                if (keySelection.ToLower() == "q")
                {
                    exit = true;
                }
                else
                {
                    bool isValid = true;
                    int selection = 0;
                    try
                    {
                        selection = int.Parse(keySelection);
                    }
                    catch(Exception)
                    {
                        isValid = false;
                    }

                    if (isValid && selection > 0 && selection <= _wardrobe.Costumes.Count)
                    {
                        var costume = _wardrobe.Costumes[selection-1];
                        DisplayCostumeDetail(costume);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid selection, press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private void DisplayCostumeDetail(WizardCostume costume)
        {
            Console.Clear();
            Console.WriteLine($"Costume Name: {costume.Name}");
            
            if (costume.Hat != null)
            {
                Console.WriteLine();
                DisplayColorTextLine(ConsoleColor.Yellow, "Hat");
                Console.WriteLine($"Name: {costume.Hat.Name}");
                Console.WriteLine($"Description: {costume.Hat.Description}");
                Console.WriteLine($"Color: {costume.Hat.Color}");
                string pointyMessage = costume.Hat.IsPointy ? "Yes" : "No";
                Console.WriteLine($"Pointy?: {pointyMessage}");
            }

            if (costume.Robe != null)
            {
                Console.WriteLine();
                DisplayColorTextLine(ConsoleColor.Yellow, "Robe");
                Console.WriteLine($"Name: {costume.Hat.Name}");
                Console.WriteLine($"Description: {costume.Hat.Description}");
                Console.WriteLine($"Color: {costume.Hat.Color}");
                string supportInvisibility = costume.Robe.SupportInvisibility ? "Yes" : "No";
                Console.WriteLine($"SupportsInvisibility?: {supportInvisibility}");
            }

            foreach (var wand in costume.Wands)
            {
                Console.WriteLine();
                DisplayColorTextLine(ConsoleColor.Yellow, "Wand");
                Console.WriteLine($"Name: {wand.Name}");
                Console.WriteLine($"Description: {wand.Description}");
                Console.WriteLine($"Color: {wand.Color}");
                Console.WriteLine($"Material: {wand.MaterialType.ToString()}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplayColorTextLine(ConsoleColor color, string message)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = prevColor;
        }
    }
}
