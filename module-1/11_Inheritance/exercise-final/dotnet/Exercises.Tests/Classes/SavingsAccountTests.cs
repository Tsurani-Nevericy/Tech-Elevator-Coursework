using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests.Classes
{
    [TestClass]
    public class SavingsAccountTests
    {
        [TestMethod]
        public void TryToWithdrawFromNegativeBalance()
        {
            SavingsAccount savAcct = new SavingsAccount("", "", -1M);

            decimal newBalance = savAcct.Withdraw(1M);

            Assert.AreEqual(-1M, newBalance);
            Assert.AreEqual(-1M, savAcct.Balance);
        }

        [TestMethod]
        public void SendPositiveIntoNegativeTest()
        {
            SavingsAccount savAcct = new SavingsAccount("", "", 1M);

            decimal newBalance = savAcct.Withdraw(2M);

            Assert.AreEqual(1M, newBalance);
            Assert.AreEqual(1M, savAcct.Balance);
        }


        [TestMethod]
        public void TryToWithdrawFromPositiveBalance()
        {
            SavingsAccount savAcct = new SavingsAccount("", "", 200M);

            decimal newBalance = savAcct.Withdraw(10M);

            Assert.AreEqual(190M, newBalance);
            Assert.AreEqual(190M, savAcct.Balance);
        }

        [TestMethod]
        public void TryToWithdrawFromBalanceBelow150()
        {
            SavingsAccount savAcct = new SavingsAccount("", "", 151M);

            decimal newBalance = savAcct.Withdraw(10M);

            Assert.AreEqual(139M, newBalance);
            Assert.AreEqual(139M, savAcct.Balance);
        }
    }
}
