using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /// <summary>
    /// A shopping cart class stores items in it.
    /// </summary>
    public class ShoppingCart
    {
        public ShoppingCart(){}
        public int TotalNumberOfItems { get; private set; } = 0;
        public decimal TotalAmountOwed { get; private set; } = 0.0m;

        public decimal GetAveragePricePerItem()
        {
            decimal result = 0;
            if (TotalNumberOfItems != 0)
            {
                result = TotalAmountOwed / TotalNumberOfItems;
            }
            return result;
        }
        public void AddItems(int numberOfItems, decimal pricePerItem)
        {
            TotalNumberOfItems += numberOfItems;
            TotalAmountOwed += numberOfItems * pricePerItem;
        }
        public void Empty()
        {
            TotalNumberOfItems = 0;
            TotalAmountOwed = 0.0m;
        }

       
    }
}
