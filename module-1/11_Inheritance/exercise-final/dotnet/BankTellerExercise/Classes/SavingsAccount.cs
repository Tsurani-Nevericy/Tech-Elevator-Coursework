using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolder, string accountNumber, decimal balance)
            :base(accountHolder, accountNumber, balance)
        {
        }

        public SavingsAccount(string accountHolder, string accountNumber)
            : base(accountHolder, accountNumber)
        { }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            // only perform transaction of positive $
            if ((Balance - amountToWithdraw) > 0)
            {
                base.Withdraw(amountToWithdraw);

                // Assess $2 fee if it goes below $150
                if (Balance < 150M)
                {
                    base.Withdraw(2.0M);
                }                
            }

            return Balance;

        }
    }
}
