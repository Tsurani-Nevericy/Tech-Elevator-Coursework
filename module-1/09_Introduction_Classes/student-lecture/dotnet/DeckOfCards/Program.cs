using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Let's store all of our cards in a list
            List<Card> cards = new List<Card>();    

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("1. Create a new card.");
                Console.WriteLine("2. Display all of the cards.");
                Console.WriteLine("3. Flip all of the cards.");
                Console.WriteLine("Q. Quit");

                char input = Console.ReadKey().KeyChar;

                if (input == '1')
                {
                    Console.Clear();
                    // Get the value for the new card
                    Console.Write("What is the value of the card (1-13): ");
                    int value = int.Parse(Console.ReadLine());

                    // Get the suit for the new card
                    Console.Write("What suit does the card have (Hearts, Diamonds, Clubs, Spades): ");
                    string suit = Console.ReadLine();
                    
                    // Is the card face up or face down
                    Console.Write("Is the card face up (True/False): ");
                    bool isFaceUp = bool.Parse(Console.ReadLine());

                    // Create the card and add to the list
                    var card = new Card(suit.ToLower(), value);
                    card.IsFaceUp = isFaceUp;

                    cards.Add(card);
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("Displaying all of the cards.");
                    Console.WriteLine();

                    // Loop through each of the cards
                    foreach (var card in cards)
                    {
                        Console.WriteLine(card);
                        Console.WriteLine();
                    }

                    Console.ReadKey();
                }
                else if (input == '3')
                {
                    Console.WriteLine($"Flipping the cards.");

                    // Loop through each of the cards and flip them
                    foreach (var card in cards)
                    {
                        card.Flip();
                    }
                }
                else if (input == 'Q' || input == 'q')
                {
                    exit = true;
                }

                // Wait for user to press enter and clear screen.
                Console.Clear();
            }
        }
    }
}
