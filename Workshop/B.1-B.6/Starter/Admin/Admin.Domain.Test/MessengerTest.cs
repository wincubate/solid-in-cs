using Admin.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Domain.Test
{
    [TestClass]
    public class MessengerTest
    {
        [TestMethod]
        public async Task Test_MessengerSendSingleMessage_WithAvailableTemplateInCulture_Ok()
        {
            // TODO: Fill in test for successful case
        }

        [ExpectedException(typeof(AdminException))]
        [TestMethod]
        public async Task Test_MessengerSendSingleMessage_WithNoAvailableTemplateInCulture_Throws()
        {
            // TODO: Fill in test for unsuccessful case
        }
    }
}
