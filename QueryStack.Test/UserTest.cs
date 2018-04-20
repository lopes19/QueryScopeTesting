using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryStack.Domain.Model.Users;

namespace QueryStack.Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void Users_ValidaData()
        {
            var user = new User("My name", 18, true, RegisterStatus.AWAITING_APPROVAL);

            Assert.AreEqual("My name", user.Name);
            Assert.AreEqual(18, user.Age);
            Assert.AreEqual(true, user.Enabled);
            Assert.AreEqual(RegisterStatus.AWAITING_APPROVAL, user.Status);
        }

        ///TODO: Build tests to another scenarios...
    }
}
