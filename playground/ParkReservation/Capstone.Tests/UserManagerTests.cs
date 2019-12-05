using Microsoft.VisualStudio.TestTools.UnitTesting;
using Security.BusinessLogic;
using Security.DAO;
using Security.Exceptions;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Capstone.Tests
{
    /// <summary>
    /// Integration tests for the UserManager class
    /// </summary>
    [TestClass]
    public class UserManagerTests
    {
        /// <summary>
        /// The connection string used for the Park DAO and the User Manager
        /// </summary>
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=npcampground;Integrated Security=true";

        /// <summary>
        /// Used to begin a transaction during initialize and rollback during cleanup
        /// </summary>
        private TransactionScope _tran = null;

        /// <summary>
        /// Used by the User Manager to interact with the database
        /// </summary>
        private IUserSecurityDAO _db = null;

        /// <summary>
        /// The main object to be tested in this class
        /// </summary>
        private UserManager _userMgr = null;

        /// <summary>
        /// Set up the database before each test  
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _db = new UserSecurityDAO(_connectionString);
            _userMgr = new UserManager(_db);

            // Initialize a new transaction scope. This automatically begins the transaction.
            _tran = new TransactionScope();
        }

        /// <summary>
        /// Cleanup runs after every single test
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            _tran.Dispose(); //<-- disposing the transaction without committing it means it will get rolled back
        }

        #region Register

        /// <summary>
        /// Tests the register user positive use case
        /// </summary>
        [TestMethod()]
        public void TestRegisterWithGoodPassword()
        {
            User user = new User();
            user.FirstName = "Chris";
            user.LastName = "Rupp";
            user.Email = "!@#$%^@tech.com";
            user.Username = "!@#$%^";
            user.Password = "bob";
            user.ConfirmPassword = "bob";
            _userMgr.RegisterUser(user);

            // Verify the user account was created and logged in after registration
            Assert.IsTrue(_userMgr.IsAuthenticated);
        }

        /// <summary>
        /// Tests the register user with mismatched passwords
        /// </summary>
        [TestMethod()]
        public void TestRegisterWithBadPassword()
        {
            User user = new User();
            user.FirstName = "Chris";
            user.LastName = "Rupp";
            user.Email = "!@#$%^@tech.com";
            user.Username = "!@#$%^";
            user.Password = "bob";
            user.ConfirmPassword = "bobby";

            try
            {
                _userMgr.RegisterUser(user);
                throw new AssertFailedException();
            }
            catch(PasswordMatchException)
            {
                // This is the expected exception do nothing so the test passes
            }

        }

        /// <summary>
        /// Tests the register user with a pre-existing user
        /// </summary>
        [TestMethod()]
        public void TestRegisterWithExistingUser()
        {
            User user = new User();
            user.FirstName = "Chris";
            user.LastName = "Rupp";
            user.Email = "!@#$%^@tech.com";
            user.Username = "!@#$%^";
            user.Password = "bob";
            user.ConfirmPassword = "bob";

            try
            {
                _userMgr.RegisterUser(user);
                _userMgr.RegisterUser(user);
                throw new AssertFailedException();
            }
            catch (UserExistsException)
            {
                // This is the expected exception do nothing so the test passes
            }

        }

        /// <summary>
        /// Tests the register user with a pre-existing user
        /// </summary>
        [TestMethod()]
        public void TestRegisterCreatesStandardUserRole()
        {
            User user = new User();
            user.FirstName = "Chris";
            user.LastName = "Rupp";
            user.Email = "!@#$%^@tech.com";
            user.Username = "!@#$%^";
            user.Password = "bob";
            user.ConfirmPassword = "bob";

            _userMgr.RegisterUser(user);
            Assert.IsTrue(_userMgr.Permission.IsStandardUser);
        }

        #endregion

        #region Login

        /// <summary>
        /// Tests the register user with a pre-existing user
        /// </summary>
        [TestMethod()]
        public void TestLogin()
        {
            User user = new User();
            user.FirstName = "Chris";
            user.LastName = "Rupp";
            user.Email = "!@#$%^@tech.com";
            user.Username = "!@#$%^";
            user.Password = "bob";
            user.ConfirmPassword = "bob";

            _userMgr.RegisterUser(user);
            _userMgr.LogoutUser();
            _userMgr.LoginUser(user.Username, user.Password);

            // Verify the user account was logged in
            Assert.IsTrue(_userMgr.IsAuthenticated);
        }

        /// <summary>
        /// Tests the login with and invalid user name
        /// </summary>
        [TestMethod()]
        public void TestLoginInvalidUsername()
        {
            try
            {
                _userMgr.LoginUser("!@#$%^", "bob");
                throw new AssertFailedException();
            }
            catch (UserDoesNotExistException)
            {
                // This is the expected exception do nothing so the test passes
            }

        }

        /// <summary>
        /// Tests the login with an invalid password
        /// </summary>
        [TestMethod()]
        public void TestLoginInvalidPassword()
        {
            User user = new User();
            user.FirstName = "Chris";
            user.LastName = "Rupp";
            user.Email = "!@#$%^@tech.com";
            user.Username = "!@#$%^";
            user.Password = "bob";
            user.ConfirmPassword = "bob";

            _userMgr.RegisterUser(user);
            _userMgr.LogoutUser();
            
            try
            {
                _userMgr.LoginUser(user.Username, "");
                throw new AssertFailedException();
            }
            catch (PasswordMatchException)
            {
                // This is the expected exception do nothing so the test passes
            }
        }

        #endregion

        #region Logout

        /// <summary>
        /// Tests the logout
        /// </summary>
        [TestMethod()]
        public void TestLogout()
        {
            User user = new User();
            user.FirstName = "Chris";
            user.LastName = "Rupp";
            user.Email = "!@#$%^@tech.com";
            user.Username = "!@#$%^";
            user.Password = "bob";
            user.ConfirmPassword = "bob";
            _userMgr.RegisterUser(user);

            // Verify the user account was created and logged in after registration
            Assert.IsTrue(_userMgr.IsAuthenticated);

            _userMgr.LogoutUser();
            Assert.IsFalse(_userMgr.IsAuthenticated);
        }

        #endregion
    }
}
