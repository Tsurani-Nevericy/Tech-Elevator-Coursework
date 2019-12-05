using Lecture.Farming;
using System;
using System.Collections.Generic;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
           //
            // OLD MACDONALD
            //
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

     

            List<ISingable> singingList = new List<ISingable>();
            singingList.Add(new Horse());
            singingList.Add(new Pig());
            singingList.Add(new Duck());
            singingList.Add(new Pig());
            singingList.Add(new Tractor());
            


            foreach (ISingable thing in singingList)
            {
                Console.WriteLine("And on his farm there was a " + thing.Name + " ee ay ee ay oh");
                Console.WriteLine("With a " + thing.MakeSoundTwice() + " here and a " + thing.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + thing.MakeSoundOnce() + ", there a " + thing.MakeSoundOnce() + " everywhere a " + thing.MakeSoundTwice());
                
                // Rarely is this a good idea.
                //if (thing is ISellable)
                //{
                //    ISellable merch = (ISellable)thing;
                //    Console.WriteLine($"And this {thing.Name} can be yours for just ${merch.Price}!");
                //}

                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();
            }

            List<ISellable> sellingList = new List<ISellable>();
            sellingList.Add(new Horse());
            sellingList.Add(new Apple());
            // sellingList.Add(new Tractor());

         


            Console.ReadLine();
        }
    }
}