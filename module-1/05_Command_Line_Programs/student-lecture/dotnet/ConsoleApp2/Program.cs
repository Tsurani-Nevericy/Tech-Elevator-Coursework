using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DEFAULT_OPTIONS = 10;
            const int MAXO = 1000;
            const int MINO = 2;
            const int MAXB = 10000;
            const int MINB = 1;
            int oddOptions = 0;
            const decimal BALANCE = 100m;
            decimal balance = 0;
            bool finished = false;
            Console.WriteLine("It is time to spin the wheel!");
            Console.ReadKey();

            Console.WriteLine("Would you like to play a default game? (yes/no)");
            string response = Console.ReadLine();
            while (response != "yes" && response != "no")
            {
                Console.WriteLine("Please enter either yes or no.");
                response = Console.ReadLine();
            }
            if (response == "yes")
            {
                oddOptions = DEFAULT_OPTIONS;
                balance = BALANCE;
            }
            else
            {
                Console.WriteLine("You have chosen to play a customized game.");
                Console.WriteLine("Please choose how many possibilities you want on the wheel. (" + MINO + " - " + MAXO + ")");
                int intResponse = int.Parse(Console.ReadLine());
                while (intResponse < MINO || intResponse > MAXO)
                {
                    Console.WriteLine("Please choose how many possibilities you want on the wheel. (" + MINO + " - " + MAXO + ")");
                    intResponse = int.Parse(Console.ReadLine());
                }
                oddOptions = intResponse;
                Console.WriteLine("Please choose how much money you want to start with. (" + MINB + " - " + MAXB + ")");
                intResponse = int.Parse(Console.ReadLine());
                while (intResponse < MINB || intResponse > MAXB)
                {
                    Console.WriteLine("Please choose how much money you want to start with. (" + MINB + " - " + MAXB + ")");
                    intResponse = int.Parse(Console.ReadLine());
                }
                balance = intResponse;
            }

            while (!finished)
            {
                Console.WriteLine("You have a current balance of $" + balance + ".");
                Console.WriteLine("What number would you like to bet on? (1 - " + oddOptions + ")");
                int guess = 0;
                bool successfulParse = int.TryParse(Console.ReadLine(), out guess);

                while (guess < 1 || guess > oddOptions)
                {
                    Console.WriteLine("You cannot pick a number that is not on the wheel.");
                    successfulParse = int.TryParse(Console.ReadLine(), out guess);
                }

                Console.WriteLine("How much would you like to bet on number " + guess + "? (1 - "+balance+")");
                decimal bet = 0;
                successfulParse = decimal.TryParse(Console.ReadLine(), out bet);

                while (bet <= 0)
                {
                    Console.WriteLine("You cannot bet nothing!");
                    successfulParse = decimal.TryParse(Console.ReadLine(), out bet);
                }

                while (balance < bet && bet > 0)
                {
                    if (balance <= 0.0m)
                    {
                        Console.WriteLine("You have no money left!");
                        Console.ReadKey();
                        return;
                    }
                    while (bet <= 0)
                    {
                        Console.WriteLine("You cannot bet nothing!");
                        successfulParse = decimal.TryParse(Console.ReadLine(), out bet);
                    }
                    Console.WriteLine("You cannot afford that!");
                    successfulParse = decimal.TryParse(Console.ReadLine(), out bet);
                }
                string result = "";
                int spinResult = SpinTheWheel(guess, oddOptions);
                if (spinResult == guess)
                {
                    result = "correct";
                    balance += bet;
                }
                else if (guess + 1 == spinResult || guess - 1 == spinResult)
                {
                    result = "close";                    
                }
                else
                {
                    result = "wrong";
                    balance -= bet;
                }
                Console.WriteLine("You guessed " + guess + " and it landed on " + spinResult + ".");
                Console.WriteLine("You guessed "+result+"!");
                if (result == "close")
                {
                    Console.WriteLine("Your guess was 1 off, you will not lose or gain any money for that!");
                }
                Console.WriteLine("You now have a balance of $" + balance + ".");
                Console.ReadKey();
                Console.WriteLine("Would you like to play again? (yes/no)");
                response = Console.ReadLine();
                while (response != "yes" && response != "no")
                {
                    Console.WriteLine("Please enter either yes or no.");
                    response = Console.ReadLine();
                }

                if (response == "yes" && balance > 0)
                {
                    continue;
                }
                else if (balance <= 0)
                {
                    Console.WriteLine("You cannot afford to play.\nPlay again some time!");
                    return;
                }
                else
                {
                    Console.WriteLine("Play again some time!");
                    finished = true;
                }
                Console.ReadKey();
            }
        }
        static int SpinTheWheel(int guess, int oddOptions)
        {
            Random rand = new Random();
            return rand.Next(1, oddOptions);         
        }
    }
}
