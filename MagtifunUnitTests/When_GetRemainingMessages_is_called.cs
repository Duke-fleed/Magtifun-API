using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagtifunAPI;

namespace APITest
{
    [TestClass]
    public class When_GetRemainingMessages_is_called
    {
        [TestMethod]
        public void Nonnegatve_number_of_messages_should_be_returned()
        {
            var helper = new MagtifunHelper("CORRECT USER", "CORRECT PASSWORD");
            var result = helper.GetRemainingMessages();
            Assert.AreEqual(result > -1, true);
        }
    }
}
