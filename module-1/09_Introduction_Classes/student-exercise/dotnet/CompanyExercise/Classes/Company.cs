using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Company
    {
        public Company(){}
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }

        public string GetCompanySize()
        {
            string result = "large";
            if (NumberOfEmployees < 50)
            {
                result = "small";
            }
            else if (NumberOfEmployees < 251)
            {
                result = "medium";
            }
            return result;
        }
        public decimal GetProfit()
        {
            return Revenue - Expenses;
        }

    }
}
