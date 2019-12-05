using System;

namespace YummyStuff
{
    class Program
    {
        public static string Name { get; set; }

        static void Main(string[] args)
        {
            FoodMenu foodMenu = new FoodMenu("Burger Time");
            Menu menu = new Menu(foodMenu);
            menu.MainMenu();

            //FoodMenu menu = new FoodMenu("Yummy Stuffs");
            //menu.AddEntree("Cheeseburger", "Regular old cheeseburger.", 4.99M);
            //menu.AddEntree("Jalepeno Burger", "Hot stuff", 5.99M);
            //Console.WriteLine(menu.PrintMenu());
            //Console.ReadKey();
        }

    }
}
