using System;

namespace UnluckyWheel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Step right up! It's time to spin the wheel!");

            decimal playerBalance = 100.00m;

            Console.WriteLine($"Your starting balance is ${playerBalance}");

            bool finished = false;

            while (finished == false)
            {
                Console.Write("Which numbers would you like to bet on (up to three, 1-6, space separated)? ");
                string reply = Console.ReadLine();
                string[] replies = reply.Split(" ");
                int[] chosenNumbers = new int[replies.Length];
                for (int i = 0; i < replies.Length; i++)
                {
                    chosenNumbers[i] = int.Parse(replies[i]);
                }

                bool betValid = false;

                decimal betAmount = 0;

                while (betValid == false)
                {
                    Console.Write("How much would you like to bet? ");
                    betAmount = decimal.Parse(Console.ReadLine());

                    if (betAmount * chosenNumbers.Length > playerBalance || betAmount <= 0)
                    {
                        Console.WriteLine("Invalid bet!");
                    }
                    else
                    {
                        betValid = true;
                    }
                }

                Console.WriteLine("The wheel is spinning.");

                int[] winningNumbers = SpinTheWheel();

                Console.WriteLine($"The winning numbers are {string.Join(", ", winningNumbers)}!");

                for (int i = 0; i < chosenNumbers.Length; i++)
                {
                    if (Array.IndexOf(winningNumbers, chosenNumbers[i]) >= 0)
                    {
                        Console.WriteLine($"You win on {chosenNumbers[i]}!");
                        playerBalance += betAmount;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you lose on {chosenNumbers[i]}.");
                        playerBalance -= betAmount;
                    }
                }

                Console.WriteLine($"Your balance is now ${playerBalance}");

                if (playerBalance <= 0)
                {
                    Console.WriteLine("You are broke. Goodbye.");
                    finished = true;
                }
                else
                {
                    Console.Write("Would you like to keep playing (y/n)? ");
                    reply = Console.ReadLine();
                    finished = (reply == "n");               
                }
            }

        }

        static int[] SpinTheWheel()
        {
            Random rand = new Random();
            int stoppedAt = rand.Next(1, 7);

            int[] result;

            if (stoppedAt == 1)
            {
                result = new int[] { 6, 1, 2 };
            }
            else if (stoppedAt == 6)
            {
                result = new int[] { 5, 6, 1};
            }
            else
            {
                result = new int[] { stoppedAt - 1, stoppedAt, stoppedAt + 1 };
            }

            return result;
        }

    }


}
