using Microsoft.VisualStudio.TestTools.UnitTesting;
using Security.BusinessLogic;
using Security.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Capstone.Tests
{
    /// <summary>
    /// Unit tests for the Authentication class
    /// </summary>
    [TestClass]
    public class AuthenticationTests
    {
        /// <summary>
        /// Tests the generation of the salt and hash for a given password
        /// </summary>
        [TestMethod()]
        public void TestSaltAndHashGeneration()
        {
            Authentication auth = new Authentication("bob");
            Assert.IsTrue(auth.Salt.Length > 0);
            Assert.IsTrue(auth.Hash.Length > 0);
        }

        /// <summary>
        /// Tests the verification of password with a given salt
        /// </summary>
        [TestMethod()]
        public void TestSaltAndHashVerificationPass()
        {
            Authentication authOne = new Authentication("bob");
            Authentication authTwo = new Authentication("bob", authOne.Salt);
            bool isAuthenticated = authTwo.Verify(authOne.Hash);
            Assert.IsTrue(isAuthenticated);
        }

        /// <summary>
        /// Tests the verification of password with a given salt and invalid hash
        /// </summary>
        [TestMethod()]
        public void TestSaltAndHashVerificationWithInvalidHash()
        {
            Authentication authOne = new Authentication("bob");
            Authentication authTwo = new Authentication("bob", authOne.Salt);
            bool isAuthenticated = authTwo.Verify("2wgXhUDAXjDDnqT/pZroQsp4no8=");
            Assert.IsFalse(isAuthenticated);
        }

        /// <summary>
        /// Tests the verification of password with an invalid salt
        /// </summary>
        [TestMethod()]
        public void TestSaltAndHashVerificationWithInvalidSalt()
        {
            Authentication authOne = new Authentication("bob");
            Authentication authTwo = new Authentication("bob", "35xnjKTD8IN74rXICmv/fw==");
            bool isAuthenticated = authTwo.Verify(authOne.Hash);
            Assert.IsFalse(isAuthenticated);
        }

    }
}
