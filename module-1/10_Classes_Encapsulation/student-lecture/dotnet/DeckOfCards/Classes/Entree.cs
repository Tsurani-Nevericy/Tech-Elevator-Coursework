using System;
using System.Collections.Generic;
using System.Text;

namespace YummyStuff
{
    public class Entree
    {
        public string Title { get; }
        public string Description { get; }
        public decimal Price { get; }

        public Entree(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Title}\n{Description}\n{Price.ToString("C")}";
        }
    }
}
