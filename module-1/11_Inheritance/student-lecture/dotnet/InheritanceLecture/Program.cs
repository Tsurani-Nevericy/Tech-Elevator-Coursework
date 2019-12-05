using InheritanceLecture.AnimalFarm;
using System;

namespace InheritanceLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal chris = new Animal();

            Dog dog = new Dog("Bark");

            Boxer tank = new Boxer("I'm gonna knock you out.");

            Calico fluffy = new Calico("Meow");
                      
            //Console.WriteLine($"Chris: {chris.Sound}");
            //Console.WriteLine($"Tank: {tank.Sound}");
            //Console.WriteLine($"Fluffy: {fluffy.Sound}");

            //chris.Move();
            //dog.Move();
            tank.Move();
            //fluffy.Move();

            Console.ReadKey();
        }
    }
}
