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
            string messageTemplateId = Guid.NewGuid().ToString();

            IMessageTemplateRepository repository =
                new FakeMessageTemplateRepository(
                    new MessageTemplate
                    {
                        Id = 1,
                        Kind = messageTemplateId,
                        Culture = "da",
                        Subject = "Emne er dette",
                        BodyTemplate = "Hukommelses-testbesked sendt som {0}!"
                    },
                    new MessageTemplate
                    {
                        Id = 2,
                        Kind = messageTemplateId,
                        Culture = "en",
                        Subject = "Subject is this",
                        BodyTemplate = "In-memory test message sent as {0}!"
                    }
                );

            MessageTransmissionStrategyTestSpy testSpy = new MessageTransmissionStrategyTestSpy();

            Messenger messenger = new Messenger(repository, testSpy);

            User user = new User(
                name: "Jesper Gulmann Henriksen",
                email: "jgh@wincubate.net",
                phone: "+4522123631",
                preferredCulture: "da"
            );

            await messenger.SendAsync(new Message
            {
                Recipient = user,
                MessageTemplateKind = messageTemplateId,
                Culture = "da",
                Parameters = new List<object> { "TEST" }
            });

            var (actualUser, actualInstance) = testSpy.Sent.Single();
            Assert.AreEqual(user.Name, actualUser.Name);

            Assert.AreEqual("Emne er dette", actualInstance.Subject);
            Assert.AreEqual("Hukommelses-testbesked sendt som TEST!", actualInstance.Body);
        }

        [ExpectedException(typeof(AdminException))]
        [TestMethod]
        public async Task Test_MessengerSendSingleMessage_WithNoAvailableTemplateInCulture_Throws()
        {
            string messageTemplateKind = "TestKind";

            IMessageTemplateRepository repository =
                new FakeMessageTemplateRepository(
                    new MessageTemplate
                    {
                        Id = 1,
                        Kind = messageTemplateKind,
                        Culture = "en",
                        Subject = "Subject is this",
                        BodyTemplate = "In-memory test message sent as {0}!"
                    }
                );

            MessageTransmissionStrategyTestSpy testSpy = new MessageTransmissionStrategyTestSpy();

            Messenger messenger = new Messenger(repository, testSpy);

            User user = new User(
                name: "Jesper Gulmann Henriksen",
                email: "jgh@wincubate.net",
                phone: "+4522123631",
                preferredCulture: "da"
            );

            await messenger.SendAsync(new Message
            {
                Recipient = user,
                MessageTemplateKind = messageTemplateKind,
                Culture = "da",
                Parameters = new List<object> { "TEST" }
            });
        }
    }
}
