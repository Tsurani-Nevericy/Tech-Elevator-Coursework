using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
    public class BankAccount
    {
        private string accountHolderName;
        public string AccountHolderName
        {
            get { return accountHolderName; }
            set { accountHolderName = value; }
        }

        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }            
        }

        public decimal Balance { get; private set; }
        

        // Constructor
        public BankAccount(string accountHolder, string accountNumber)
        {
            this.accountHolderName = accountHolder;
            this.accountNumber = accountNumber;
            this.Balance = 0M;
        }

        public BankAccount(string accountHolder, string accountNumber, decimal balance)
        {
            this.accountHolderName = accountHolder;
            this.accountNumber = accountNumber;
            this.Balance = balance;
        }

        // Update the balance by using the DollarAmount.Plus method
        public decimal Deposit(decimal amountToDeposit)
        {
            Balance += amountToDeposit;
            return Balance;
        }

        // Update the balance by using the DollarAmount.Minus method
        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            Balance -= amountToWithdraw;
            return Balance;
        }

        public decimal TransferTo(BankAccount destination, decimal amountToTransfer)
        {
            this.Withdraw(amountToTransfer);
            destination.Deposit(amountToTransfer);

            return Balance;
        }

    }
}
