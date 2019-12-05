using Microsoft.VisualStudio.TestTools.UnitTesting;
using Security.BusinessLogic;
using Security.DAO;
using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Capstone.Tests
{
    /// <summary>
    /// Integration tests for the user security DAO
    /// </summary>
    [TestClass]
    public class UserSecurityDAOTests
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
        /// The main object to be tested in this class. This DAO is used for the user and role tables
        /// </summary>
        private IUserSecurityDAO _db = null;

        /// <summary>
        /// Set up the database before each test  
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _db = new UserSecurityDAO(_connectionString);

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

        /// <summary>
        /// Tests the user POCO methods
        /// </summary>
        [TestMethod()]
        public void TestRole()
        {
            RoleItem item = new RoleItem();
            item.Id = 1000;
            item.Name = "Bob";
            _db.AddRoleItem(item);

            var roles = _db.GetRoleItems();
            bool foundRole = false;
            foreach(var role in roles)
            {
                if(role.Id == 1000 && role.Name == "Bob")
                {
                    foundRole = true;
                }
            }
            Assert.IsTrue(foundRole, "The role 'Bob' with the ID '1000' that was added cannot be found in the database.");
        }

        /// <summary>
        /// Tests the user POCO methods
        /// </summary>
        [TestMethod()]
        public void TestUser()
        {
            Authentication auth = new Authentication("Abcd!234");

            // Test add user
            UserItem item = new UserItem();
            item.FirstName = "Chris";
            item.LastName = "Rupp";
            item.Username = "!@#$%^";
            item.Hash = auth.Hash;
            item.Salt = auth.Salt;
            item.Email = "!@#$%^@tech.com";
            item.RoleId = (int) Authorization.eRole.StandardUser;
            int id = _db.AddUserItem(item);
            Assert.AreNotEqual(0, id);

            // Test get user item by id
            UserItem itemGet = _db.GetUserItem(id);
            Assert.AreEqual(item.Id, itemGet.Id);
            Assert.AreEqual(item.FirstName, itemGet.FirstName);
            Assert.AreEqual(item.LastName, itemGet.LastName);
            Assert.AreEqual(item.Username, itemGet.Username);
            Assert.AreEqual(item.Hash, itemGet.Hash);
            Assert.AreEqual(item.Salt, itemGet.Salt);
            Assert.AreEqual(item.Email, itemGet.Email);

            // Test update user
            item.FirstName = "What";
            item.LastName = "What";
            item.Username = "What";
            item.Email = "What";
            item.Hash = "What";
            item.Salt = "What";
            Assert.IsTrue(_db.UpdateUserItem(item));

            // Test get user item by user name
            itemGet = _db.GetUserItem(item.Username);
            Assert.AreEqual(item.Id, itemGet.Id);
            Assert.AreEqual(item.FirstName, itemGet.FirstName);
            Assert.AreEqual(item.LastName, itemGet.LastName);
            Assert.AreEqual(item.Username, itemGet.Username);
            Assert.AreEqual(item.Hash, itemGet.Hash);
            Assert.AreEqual(item.Salt, itemGet.Salt);
            Assert.AreEqual(item.Email, itemGet.Email);

            // Test delete user
            _db.DeleteUserItem(id);
            var users = _db.GetUserItems();
            foreach (var user in users)
            {
                Assert.AreNotEqual(id, user.Id);
            }
        }
    }
}
