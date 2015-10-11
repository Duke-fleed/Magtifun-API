using MagtifunAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest
{
    [TestClass]
    public class When_number_or_password_is_incorrect
    {
        MagtifunHelper helper;
        [TestInitialize]
        public void TestInit()
        {
            helper = new MagtifunHelper("qwerty", "1234");
        }

        [TestMethod]
        public void SendSMS_should_return_not_logged_in()
        {
            var result = helper.SendSMS("1234", "test");
            Assert.AreEqual(result, "not_logged_in");
        }

        [TestMethod]
        public void GetRemainingMessages_should_return_minus_one()
        {
            var result = helper.GetRemainingMessages();
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void GetContactsList_should_return_null()
        {
            var result = helper.GetContactsList();
            Assert.AreEqual(result, null);
        }
    }
}
