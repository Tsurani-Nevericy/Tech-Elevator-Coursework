using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    public class Card
    {
        // Constant
        public const string MANUFACTURER = "Bicycle";
        public const string DIAMONDS = "Diamonds";
        public const string CLUBS = "Clubs";
        public const string HEARTS = "Hearts";
        public const string SPADES = "Spades";
        public const string RED = "Red";
        public const string BLACK = "Black";
        
        // Member Variable
        private string _suit = "";

        // Member Variable
        private Dictionary<string, string> _suitDisplay = new Dictionary<string, string>()
        {
            {"diamonds", DIAMONDS},
            {"clubs", CLUBS },
            {"spades", SPADES },
            {"hearts", HEARTS }
        };

        private Dictionary<int, string> _numberDisplay = new Dictionary<int, string>()
        {
            {1, "Ace"},
            {2, "Two"},
            {3, "Three" },
            {4, "Four" },
            {5, "Five" },
            {6, "Six" },
            {7, "Seven" },
            {8, "Eight" },
            {9, "Nine" },
            {10, "Ten" },
            {11, "Jack" },
            {12, "Queen" },
            {13, "King" }

        };

        // Property initialized
        public bool IsFaceUp { get; set; } = false;

        // Property
        public string Suit
        {
            get
            {
                return _suit;
            }
            set
            {
                if (value == DIAMONDS.ToLower() || 
                    value == HEARTS.ToLower() || 
                    value == SPADES.ToLower() || 
                    value == CLUBS.ToLower())
                {
                    _suit = value;
                }
            }
        }

        // Property initialized
        public int Number { get; set; } = 1;

        // Derived Property
        public string Color
        {
            get
            {
                string color = RED;

                if(_suit == SPADES || _suit == CLUBS)
                {
                    color = BLACK;
                }

                return color;
            }
        }

        public string DisplayFaceUp
        {
            get
            {
                return IsFaceUp ? "Face Up" : "Face Down";
            }
        }

        // Constructor
        public Card(string suit, int number)
        {
            Suit = suit;
            Number = number;
        }

        // Method
        public override string ToString()
        {
            return $"Suit:{_suitDisplay[_suit]}\nNumber:{_numberDisplay[Number]}\nColor:{Color}\n{DisplayFaceUp}";
        }

        // Method
        public bool Flip()
        {
            IsFaceUp = !IsFaceUp;
            return IsFaceUp;
        }
    }
}
