using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryStack.Domain.Model.Users;
using System.Collections.Generic;
using System.Linq;

namespace QueryStack.Test
{
    [TestClass]
    public class UserScopeTest
    {
        private IEnumerable<User> _userList;

        public UserScopeTest()
        {
            _userList = new List<User>
            {
                new User("User 1", 20, true, RegisterStatus.APPROVED),
                new User("User 2", 40, true, RegisterStatus.CANCELLED),
                new User("User 3", 17, true, RegisterStatus.AWAITING_APPROVAL),
                new User("User 4", 35, false, RegisterStatus.APPROVED)
            };
        }

        [TestMethod]
        public void EnabledUsers()
        {
            var result = _userList.AsQueryable().Where(UserScope.EnabledUsers);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(true, result.Any(x => x.Name == "User 1"));
            Assert.AreEqual(true, result.Any(x => x.Name == "User 2"));
            Assert.AreEqual(true, result.Any(x => x.Name == "User 3"));
            Assert.AreEqual(false, result.Any(x => x.Name == "User 4"));
        }

        [TestMethod]
        public void MajorUsers()
        {
            var result = _userList.AsQueryable().Where(UserScope.MajorUsers);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(true, result.Any(x => x.Name == "User 1"));
            Assert.AreEqual(true, result.Any(x => x.Name == "User 2"));
            Assert.AreEqual(false, result.Any(x => x.Name == "User 3"));
            Assert.AreEqual(true, result.Any(x => x.Name == "User 4"));
        }

        [TestMethod]
        public void NotCancelledUsers()
        {
            var result = _userList.AsQueryable().Where(UserScope.NotCancelledUsers);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(true, result.Any(x => x.Name == "User 1"));
            Assert.AreEqual(false, result.Any(x => x.Name == "User 2"));
            Assert.AreEqual(true, result.Any(x => x.Name == "User 3"));
            Assert.AreEqual(true, result.Any(x => x.Name == "User 4"));
        }

        [TestMethod]
        public void AvailableUsers()
        {
            var result = _userList.AsQueryable().Where(UserScope.AvailableUsers);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(true, result.Any(x => x.Name == "User 1"));
            Assert.AreEqual(false, result.Any(x => x.Name == "User 2"));
            Assert.AreEqual(false, result.Any(x => x.Name == "User 3"));
            Assert.AreEqual(false, result.Any(x => x.Name == "User 4"));
        }

        [TestMethod]
        public void AgeGratherThan()
        {
            var result = _userList.AsQueryable().Where(UserScope.AgeGratherThan(20));

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(false, result.Any(x => x.Name == "User 1"));
            Assert.AreEqual(true, result.Any(x => x.Name == "User 2"));
            Assert.AreEqual(false, result.Any(x => x.Name == "User 3"));
            Assert.AreEqual(true, result.Any(x => x.Name == "User 4"));
        }
    }
}
