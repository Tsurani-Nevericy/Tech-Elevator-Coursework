using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests.Classes
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void NewCustomerHasZeroBalance()
        {
            BankAccount account = new BankAccount("", "");
            Assert.AreEqual(0M, account.Balance);            
        }

        [TestMethod]
        public void NewCustomerHasStartingBalance()
        {
            BankAccount account = new BankAccount("", "", 100M);
            Assert.AreEqual(100M, account.Balance);    
        }

        [TestMethod]
        public void DepositIncreasesBalance()
        {
            BankAccount account = new BankAccount("", "");

            decimal newBalance= account.Deposit(100M);

            Assert.AreEqual(100M, newBalance);
            Assert.AreEqual(100M, account.Balance);
        }

        [TestMethod]
        public void WithdrawDecreasesBalance()
        {
            BankAccount account = new BankAccount("", "");

            decimal newBalance = account.Withdraw(100M);

            Assert.AreEqual(-100M, newBalance);
            Assert.AreEqual(-100M, account.Balance);
        }

        [TestMethod]
        public void TransferTests()
        {
            BankAccount source = new BankAccount("", "", 50M);
            BankAccount destination = new BankAccount("", "");

            decimal newSourceBalance = source.TransferTo(destination, 24M);

            Assert.AreEqual(26M, newSourceBalance);
            Assert.AreEqual(24M, destination.Balance);
            Assert.AreEqual(26M, source.Balance);
        }
    }
}
