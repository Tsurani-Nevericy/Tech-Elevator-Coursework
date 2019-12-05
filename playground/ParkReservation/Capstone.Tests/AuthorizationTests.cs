using Microsoft.VisualStudio.TestTools.UnitTesting;
using Security.BusinessLogic;
using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    /// <summary>
    /// Unit tests for the Authorization class
    /// </summary>
    [TestClass]
    public class AuthorizationTests
    {
        /// <summary>
        /// Tests is administrator role
        /// </summary>
        [TestMethod()]
        public void TestIsAdministrator()
        {
            UserItem user = new UserItem();
            user.RoleId = (int) Authorization.eRole.Administrator;

            Authorization auth = new Authorization(user);
            Assert.IsTrue(auth.IsAdministrator);
        }

        /// <summary>
        /// Tests is standard user role
        /// </summary>
        [TestMethod()]
        public void TestIsStandardUser()
        {
            UserItem user = new UserItem();
            user.RoleId = (int)Authorization.eRole.StandardUser;

            Authorization auth = new Authorization(user);
            Assert.IsTrue(auth.IsStandardUser);
        }

        /// <summary>
        /// Tests is unkown role
        /// </summary>
        [TestMethod()]
        public void TestIsUnknown()
        {
            UserItem user = new UserItem();

            Authorization auth = new Authorization(user);
            Assert.IsTrue(auth.IsUnknown);
        }
    }
}
