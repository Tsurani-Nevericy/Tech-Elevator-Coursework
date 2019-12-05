using System;
using WizardWardrobe;
using WizardWardrobe.Exceptions;

namespace WizardWardrobeCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCostume();

            // Use this to determine where your program starts
            //string filePath = Environment.CurrentDirectory;
            try
            {
                string filePath = @"..\..\..\..\..\Files\Costumes.txt";
                Wardrobe wardrobe = new Wardrobe(filePath);
                Menu menu = new Menu(wardrobe);
                menu.MainMenu();
            }
            catch(ArticleExistsException ex)
            {
                Console.WriteLine();
                Console.WriteLine($"The article {ex.DuplicateArticle.Name} already exists in the costume.");
                Console.ReadKey();
            }
            catch(UnknownArticleException)
            {
                Console.WriteLine();
                Console.WriteLine("The article is not of a known type.");
                Console.ReadKey();
            }
            catch(UnknownPropertyException)
            {
                Console.WriteLine();
                Console.WriteLine("The property is unknown.");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }
        }

        private static void TestCostume()
        {
            WizardCostume costume = new WizardCostume();
            Robe robe = new Robe();
            robe.Color = "Blue";
            robe.Description = "My first robe";
            robe.Name = "Midday sky";
            robe.SupportInvisibility = false;
            costume.AddArticle(robe);

            Hat hat = new Hat();
            hat.Color = "Silver";
            hat.Description = "My first hat";
            hat.Name = "Sir pointy";
            hat.IsPointy = true;
            costume.AddArticle(hat);

            Wand wand = new Wand();
            wand.Color = "Chrome";
            wand.Description = "My first wand";
            wand.Name = "Wanda";
            costume.AddArticle(wand);

            wand = new Wand();
            wand.Color = "Chrome";
            wand.Description = "My second wand";
            wand.Name = "Wandy";
            costume.AddArticle(wand);

            Console.WriteLine($"Robe: {costume.Robe.Name}");
            Console.WriteLine($"Hat: {costume.Hat.Name}");
            var wands = costume.Wands;
            foreach (var item in wands)
            {
                Console.WriteLine($"Wand: {item.Name}");
            }

            Console.ReadKey();
        }
    }
}
