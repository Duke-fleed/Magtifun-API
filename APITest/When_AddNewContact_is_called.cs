using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagtifunAPI;
using System.Linq;

namespace APITest
{
    [TestClass]
    public class When_AddNewContact_is_called
    {
        MagtifunHelper helper;
        [TestInitialize]
        public void TestInit()
        {
          helper = new MagtifunHelper("CORRECT USER", "CORRECT PASSWORD");
        }

        [TestMethod]
        public void success_should_be_returned_and_contactslist_should_contain_new_contact()
        {
            
            var number = "571123456";
            var result = helper.AddNewContact("test","571123456", gender:Gender.Female, dateOfBirth: DateTime.Now);
            var newContact = helper.GetContactsList().Where(x => x.Number == number).FirstOrDefault();
            Assert.AreEqual("success", result);
            Assert.AreNotEqual(null, newContact);
        }

        [TestMethod]
        public void if_number_is_incorrect_incorrect_mobile_number_should_be_returned()
        {
            var result = helper.AddNewContact("test", "123", gender: Gender.Female, dateOfBirth: DateTime.Now);
            Assert.AreEqual("incorrect_mobile_number", result);
        }
    }
}
