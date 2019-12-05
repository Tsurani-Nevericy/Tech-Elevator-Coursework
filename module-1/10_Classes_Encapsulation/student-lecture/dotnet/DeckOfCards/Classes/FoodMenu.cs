using System;
using System.Collections.Generic;
using System.Text;

namespace YummyStuff
{
    public class FoodMenu
    {
        public string RestaurantName { get; }

        /// <summary>
        /// The Key is the Entree Title
        /// </summary>
        private Dictionary<string, Entree> _entrees = new Dictionary<string, Entree>();

        public FoodMenu(string restaurantName)
        {
            RestaurantName = restaurantName;
        }

        public string PrintMenu()
        {
            string result = $"{RestaurantName.PadLeft(20)}\n\n";
            foreach(var entree in _entrees.Values)
            {
                result += entree.ToString() + "\n\n";
            }
            return result;
        }

        public bool AddEntree(string title, string description, decimal price)
        {
            bool result = false;
            if (!_entrees.ContainsKey(title))
            {
                Entree entree = new Entree(title, description, price);
                _entrees.Add(title, entree);
                result = true;
            }
            return result;
        }
    }
}
