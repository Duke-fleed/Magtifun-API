using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagtifunAPI;

namespace APITest
{
    [TestClass]
    public class When_ContactsList_is_requested_and_there_is_at_least_one_record
    {
        [TestMethod]
        public void List_of_magtifuncontact_should_be_returned()
        {
            var helper = new MagtifunHelper("CORRECT USER", "CORRECT PASSWORD");
            var contacts = helper.GetContactsList();
            Assert.AreEqual(contacts.Count > 0, true);
        }
    }
}
