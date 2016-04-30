using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BIMCoordinatorTool;

namespace MailTester
{
    [TestClass]
    public class MailTesting
    {
        [TestMethod]
        public void TryToSendMail()
        {
            var MH = new MailingApi();

            MH.serviceSetup();
            MH.SendMail();
        }

        [TestMethod]
        public void ReadMail()
        {
            var MH = new MailingApi();

            MH.serviceSetup();
            MH.readMail();
        }
    }
}
