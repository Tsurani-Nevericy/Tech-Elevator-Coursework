using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests.Classes
{
    [TestClass]
    public class CheckingAccountTests
    {
        [TestMethod]
        public void WithdrawNegativeWithFeeBalance_Test()
        {
            CheckingAccount chkAccount = new CheckingAccount("", "", -1M);

            decimal newBalance = chkAccount.Withdraw(1M);

            Assert.AreEqual(-12M, newBalance);
            Assert.AreEqual(-12M, chkAccount.Balance);            
        }

        [TestMethod]
        public void WithdrawPositiveWithFee_Test()
        {
            CheckingAccount chkAccount = new CheckingAccount("", "", -1M);

            decimal newBalance = chkAccount.Withdraw(2M);

            Assert.AreEqual(-13M, newBalance);
            Assert.AreEqual(-13M, chkAccount.Balance);
        }

        [TestMethod]
        public void WithdrawNegativeBalanceBelow100_Test()
        {
            CheckingAccount chkAccount = new CheckingAccount("", "", -100M);

            decimal newBalance = chkAccount.Withdraw(2M);

            Assert.AreEqual(-100M, newBalance);
            Assert.AreEqual(-100M, chkAccount.Balance);
        }

        [TestMethod]
        public void WithdrawPositiveBalance_Test()
        {
            CheckingAccount chkAccount = new CheckingAccount("", "", 10M);

            decimal newBalance = chkAccount.Withdraw(5M);

            Assert.AreEqual(5M, newBalance);
            Assert.AreEqual(5M, chkAccount.Balance);
        }
    }
}
