using AllMyPeople;
using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Review
            Person chris = new Person();
            chris.Sneeze();
            chris.Age = 46;

            Person blaize = new Person();
            blaize.Age = 46;

            if (chris.Equals(blaize))
            {
                Console.WriteLine("Contents Equal");
            }
            else
            {
                Console.WriteLine("Contents Not Equal");
            }

            //if (chris.Equals(blaize))
            if (chris == blaize)
            {
                Console.WriteLine("References Equal");
            }
            else
            {
                Console.WriteLine("References Not Equal");
            }

            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Creating lists of integers
            List<int> studentAges = new List<int>();

            // Creating lists of strings
            var oldNames = new List<string>();
            var newNames = new List<string>();

            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////
            if (oldNames == newNames)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }


            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            oldNames.Add("Chris");
            oldNames.Add("Joe");
            newNames.Add("Blaize");
            newNames.Add("Bill");

            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////
            string[] arrayNames = oldNames.ToArray();
            newNames.AddRange(arrayNames);
            PrintNames(newNames.ToArray());

            //////////////////
            // ACCESSING BY INDEX
            //////////////////
            Console.WriteLine($"First Name: {newNames[0]}");


            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            Console.WriteLine();
            PrintListNames(newNames);

            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////
            newNames.Remove("Joe");
            Console.WriteLine();
            PrintListNames(newNames);

            newNames.Reverse();
            Console.WriteLine();
            PrintListNames(newNames);

            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////
            newNames.Sort();
            Console.WriteLine();
            PrintListNames(newNames);

            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.


            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            Queue<string> names = new Queue<string>();
            names.Enqueue("Therese");
            names.Enqueue("Elizabeth");
            names.Enqueue("Kevin");

            Console.WriteLine();
            Console.WriteLine("Queue me up");
            while (names.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Before Dequeue");
                PrintNames(names.ToArray());
                Console.WriteLine();

                string name = names.Dequeue();
                Console.WriteLine(name);
            }

            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 
            Stack<string> stackNames = new Stack<string>();
            stackNames.Push("Therese");
            stackNames.Push("Elizabeth");
            stackNames.Push("Kevin");

            Console.WriteLine();
            Console.WriteLine("Stack me up");
            while (stackNames.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Before Stack");
                PrintNames(stackNames.ToArray());
                Console.WriteLine();

                string name = stackNames.Pop();
                Console.WriteLine(name);
            }

            ////////////////////
            // POPPING THE STACK
            ////////////////////


            Console.ReadKey();

        }

        private static void PrintNames(string[] names)
        {
            for(int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }

        private static void PrintListNames(List<string> names)
        {
            //for (int i = 0; i < names.Count; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private static void PrintQueueNames(Queue<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
