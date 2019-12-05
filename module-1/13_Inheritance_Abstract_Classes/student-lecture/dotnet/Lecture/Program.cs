using Lecture.Farming;
using System;
using System.Collections.Generic;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISound> animals = new List<ISound>();

           //
            // OLD MACDONALD
            //
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

            // Let's try singing about a Farm Animal
            animals.Add(new Horse());
            animals.Add(new Chicken());
            animals.Add(new Ferrari());
            animals.Add(new Pig());

            foreach (var animal in animals)
            {

                Pig pig = animal as Pig;
                if (pig != null)
                {
                    Console.WriteLine($"Am I a FarmAnimal {((FarmAnimal)animal).MakeSoundTwice()}");
                    Console.WriteLine($"Or am i a Pig {pig.MakeSoundTwice()}");
                    Console.WriteLine();
                }

                if (animal is FarmAnimal)
                {
                    FarmAnimal farmAnimal = (FarmAnimal)animal;
                    Console.WriteLine("And on his farm there was a " + farmAnimal.Name + " ee ay ee ay oh");
                    Console.WriteLine("With a " + farmAnimal.MakeSoundTwice() + " here and a " + farmAnimal.MakeSoundTwice() + " there");
                    Console.WriteLine("Here a " + farmAnimal.MakeSoundOnce() + ", there a " + farmAnimal.MakeSoundOnce() + " everywhere a " + farmAnimal.MakeSoundTwice());
                    Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("I'm not a farm animal dude, have some respect.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            foreach (var animal in animals)
            {
                Console.WriteLine($"Sound I make going round and round is {animal.MakeSound()}");
            }


            // What if we wanted to sing about other things on the farm that were 
            // singable but not farm animals?
            // Can it be done? 

            Console.ReadLine();
        }
    }
}