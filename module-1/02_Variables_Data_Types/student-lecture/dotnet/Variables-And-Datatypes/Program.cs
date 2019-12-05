using System;

namespace Variables_And_Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		    */
            int numberOfExercises = 26;

            //Console.WriteLine($"1) numberOfExercises = {numberOfExercises}");

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half = 0.5;

            //Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name = "TechElevator";

            //Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            byte seasonsOfFirefly = 1;

            //Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";

            //Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */
            float pi = 3.1416F;
            //Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            string myName = "Pishoy";

            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            byte numberOfMouseButtons = 15;

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            float phoneBatteryRemaining = 0.60F;

            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int diff = 121 - 27;

            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double addDouble = 12.3 + 32.1;

            /*
            12. Create a string that holds your full name.
            */
            string firstName = "Jesse";
            string lastName = "Foltz";
            string fullName = $"{firstName} {lastName}";
            Console.WriteLine(fullName);

            fullName = firstName + " " + lastName;
            Console.WriteLine(fullName);

            fullName = "Jesse Foltz";
            Console.WriteLine(fullName);
            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string nameGreeting = $"Hello, {fullName}";
            Console.WriteLine(nameGreeting);
            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            fullName = fullName + " Esquire";
            Console.WriteLine(fullName);

            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            fullName += " Esquire";
            Console.WriteLine(fullName);

            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            int movieVer = 2;
            string movieName = $"Saw" + movieVer;
            Console.WriteLine(movieName);

            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */
            movieName += 0;

            /*
            18. What is 4.4 divided by 2.2?
            */
            double result = 4.4 / 2.2;

            /*
            19. What is 5.4 divided by 2?
            */
            result = 5.4 / 2;

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            result = 5 / 2;
            Console.WriteLine(result);
            /*
            21. What is 5.0 divided by 2?
            */
            result = 5.0 / 2;
            Console.WriteLine(result);

            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */
            decimal balance = 1234.56M;

            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            int remainder = 5 % 2;

            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */
            int num1 = 3;
            int num2 = 1000000000;
            int numResult = num1 * num2;

            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */
            bool doneWithExercises = false;

            /*
            26. Now set doneWithExercise to true.
            */
            doneWithExercises = true;

            Console.ReadKey();

        }
    }
}
