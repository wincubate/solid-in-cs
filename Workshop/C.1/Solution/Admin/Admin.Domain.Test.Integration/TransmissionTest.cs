using Admin.Domain.Email;
using Admin.Domain.Interfaces;
using Admin.Domain.Sms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Admin.Domain.Test.Integration
{
    // No reason to introduce DI container here!

    [TestClass]
    [TestCategory("Integration")]
    public class TransmissionTest
    {
        private User _user;
        private InstantiatedMessage _instance;

        [TestInitialize]
        public void TestInitialize()
        {
            _user = new User(
                name: "Jesper Gulmann Henriksen",
                email: "jgh@wincubate.net",
                phone: "+4522123631",
                preferredCulture: "da"
            );
            _instance = new InstantiatedMessage(
                "This is the subject",
                "This is the body"
            );
        }

        [TestMethod]
        [Ignore]
        async public Task Test_SendEmail_Ok()
        {
            IMessageTransmissionStrategy strategy = new SendGridEmailTransmissionStrategy();

            await strategy.TransmitAsync(_user, _instance);
        }

        [TestMethod]
        [Ignore]
        async public Task Test_SendSms_Ok()
        {
            IMessageTransmissionStrategy strategy = new TwilioSmsTransmissionStrategy();

            await strategy.TransmitAsync(_user, _instance);
        }
    }
}
