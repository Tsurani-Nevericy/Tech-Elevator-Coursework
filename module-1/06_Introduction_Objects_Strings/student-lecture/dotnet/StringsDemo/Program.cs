using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // REVIEW
            //int[] nums = new int[45];
            //int[] myNums = nums;
            //if(nums == myNums)
            //{
            //    Console.WriteLine("My arrays are equal");
            //}


            //Console.WriteLine("Hey enter a number...");
            //string numberStr = Console.ReadLine();
            //int number;

            //try
            //{
            //    number = int.Parse(numberStr);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine("Press any key to continue...");
            //    Console.ReadKey();
            //}

            //// or

            //if(!int.TryParse(numberStr, out number))
            //{
            //    Console.WriteLine($"Could not parse '{numberStr}'");
            //    Console.WriteLine("Press any key to continue...");
            //    Console.ReadKey();
            //}

            string name = "Ada Lovelace";
            Console.WriteLine(name);
            Console.WriteLine();

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. ");
            Console.WriteLine($"{name[0]}{name[name.Length-1]}");
            Console.WriteLine();

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: ");
            Console.WriteLine(name.Substring(0,3));
            Console.WriteLine();

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine("Last 3 characters: ");
            Console.WriteLine(name.Substring(0, 3));
            Console.WriteLine(name.Substring(name.Length-3));
            Console.WriteLine();

            // 4. What about the last word?
            // Output: Lovelace

            Console.WriteLine("Last Word: ");
            string[] names = name.Split(" ");
            Console.WriteLine(names[names.Length - 1]);
            Console.WriteLine();

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine("Contains \"Love\"");
            if (name.Contains("Love"))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.WriteLine();

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine("Index of \"lace\": ");
            Console.WriteLine(name.IndexOf("lace"));
            Console.WriteLine();

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            Console.WriteLine("Number of \"a's\": ");
            //int numberAs = name.ToUpper().Split("A").Length - 1;
            string upperName = name.ToUpper();
            string[] splitAs = upperName.Split("A");
            int numberAs = splitAs.Length - 1;
            Console.WriteLine(numberAs);
            Console.WriteLine();

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            Console.WriteLine(name);
            Console.WriteLine(name.Replace("Ada", "Ada, Countess of Lovelace"));
            Console.WriteLine();

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if(name == null || name == "")
            {
                Console.WriteLine("All Done");
            }

            Console.ReadKey();
        }
    }
}