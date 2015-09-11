using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagtifunAPI;

namespace APITest
{
    [TestClass]
    public class When_SendSMS_is_called
    {
        [TestMethod]
        public void success_should_be_returned()
        {
            var helper = new MagtifunHelper("CORRECT USER", "CORRECT PASSWORD");
            var result = helper.SendSMS("CORRECT NUMBER", "Test");
            Assert.AreEqual(result, "success");
        }
    }
}
