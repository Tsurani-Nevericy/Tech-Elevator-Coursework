using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryCollection
{
    class Program
    {
        static void GiveMeNames(string[] names)
        {
            // Convert array to List
            List<string> giveMeList = new List<string>();
            giveMeList.AddRange(names);

            var myList = names.ToList();            
        }

        static void PrintList(List<string> data)
        {
            // for loops are good to use when you know how many times you want
            // to loop
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(data[i]);
            }

            // foreach loops are good to use when you want to loop through an entire collection
            // or array from the beginning to the end
            foreach(var item in data)
            {
                Console.WriteLine(item);
            }

        }

        static void Main(string[] args)
        {
            // Review
            List<string> names = new List<string>();
            names.Add("Chris");

            // Convert List to Array
            string[] stringArray = names.ToArray();
            GiveMeNames(names.ToArray());

            PracticeSet();

            Console.Clear();
            Console.WriteLine("Welcome to the Person / Height Database");
            Console.WriteLine();

            // 1. Let's create a new Dictionary that could hold string, ints
            //      | "Josh"    | 70 |
            //      | "Bob"     | 72 |
            //      | "John"    | 75 |
            //      | "Jack"    | 73 |

            Dictionary<string, int> people = new Dictionary<string, int>();

            string input = "y";
            while (input == "yes" || input == "y")
            {
                Console.Write("What is the person's name?: ");
                string name = Console.ReadLine();

                Console.Write("What is the person's height (in inches)?: ");
                int height = int.Parse(Console.ReadLine());

                // 2. Check to see if that name is in the dictionary
                bool exists = people.ContainsKey(name);

                if (!exists)
                {
                    Console.WriteLine($"Adding {name} with new value.");
                    // 3. Put the name and height into the dictionary                    
                    people.Add(name, height);
                }
                else
                {
                    Console.WriteLine($"Overwriting {name} with new value.");
                    // 4. Overwrite the current key with a new value
                    people[name] = height;
                }

                Console.WriteLine();
                Console.Write("Would you like to enter another person (yes/no)? ");
                input = Console.ReadLine().ToLower();
            }

            Console.Write("Type \"all\" to print all names OR \"search\" to print out single name: ");
            input = Console.ReadLine().ToLower();

            if (input == "search")
            {
                Console.Write("Which name are you looking for? ");
                input = Console.ReadLine();

                //5. Let's get a specific name from the dictionary
                Console.WriteLine($"{input} is {people[input]} inches tall.");

            }
            else if (input == "all")
            {
                Console.WriteLine();
                Console.WriteLine(".... printing ...");

                //6. Let's print each item in the dictionary
                PrintDictionary(people);
            }

            Console.WriteLine();
            Console.WriteLine("Done...");

            //7. Let's get the average height of the people in the dictionary
            var heights = people.Values.ToArray();
            var avgHeight = AverageHeight(heights);
            Console.WriteLine($"Average height {avgHeight.ToString("N2")}");

            Console.ReadLine();
        }

        static double AverageHeight(int[] heights)
        {
            double result = 0.0;

            foreach(int height in heights)
            {
                result += height;
            }

            result /= heights.Length;

            return result;
        }

        static void PrintDictionary(Dictionary<string, int> people)
        {
            Console.WriteLine("Name    Height");
            Console.WriteLine("--------------");
            
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
            foreach (var person in  people)
            {
                Console.WriteLine($"{person.Key}  {person.Value}");
            }

            //Console.WriteLine("Name");
            //Console.WriteLine("--------------");

            //// Looping through a dictionary involves using a foreach loop
            //// to look at each item, which is a key-value pair
            //foreach (var name in people.Keys)
            //{
            //    Console.WriteLine($"{name});
            //}

            //Console.WriteLine("Height");
            //Console.WriteLine("--------------");

            //// Looping through a dictionary involves using a foreach loop
            //// to look at each item, which is a key-value pair
            //foreach (var height in people.Values)
            //{
            //    Console.WriteLine($"{height});
            //}
        }

        static void PracticeSet()
        {
            HashSet<string> oldNames = new HashSet<string>();
            oldNames.Add("Chris");
            oldNames.Add("Bob");
            oldNames.Add("bob");
            oldNames.Add("Chris");
            oldNames.Add("Amy");
            
            List<string> sortedNames = oldNames.ToList();
            sortedNames.Sort();

            PrintNames(sortedNames.ToArray());

            HashSet<string> newNames = new HashSet<string>();
            newNames.Add("Chris");
            newNames.Add("Bob");
            newNames.Add("Charles");

            // Merge the sets together
            oldNames.UnionWith(newNames);
            PrintNames(oldNames.ToArray());

            oldNames.Remove("Charles");

            // Modify set to only have names in common with both sets
            oldNames.IntersectWith(newNames);
            PrintNames(oldNames.ToArray());
        }

        public static void PrintNames(string[] names)
        {
            Console.Clear();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
    }
}
