using Admin.Domain;
using Admin.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cinema.Domain.Messaging.Test
{
    [TestClass]
    public class TextSubstitutorTest
    {
        [TestMethod]
        public void Test_TextSubstitutor_Ok()
        {
            MessageTemplate template = new MessageTemplate
            {
                Id = 1,
                Kind = "TestKind",
                Culture = "en",
                Subject = "This is the Subject",
                BodyTemplate = "Hello, {0}. The time is now {1}"
            };

            TextSubstitutor substitutor = new TextSubstitutor();

            DateTime now = DateTime.Now;
            IEnumerable<object> parameters = new List<object>
            {
                "World",
                now
            };

            string actual = substitutor.Substitute(template, parameters);
            string expected = $"Hello, World. The time is now {now}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(AdminException))]
        public void Test_TextSubstitutorMissingParameter_Throws()
        {
            MessageTemplate template = new MessageTemplate
            {
                Id = 1,
                Kind = "TestKind",
                Culture = "en",
                BodyTemplate = "Hello, {0}. The time is now {1}, but not {2}"
            };

            TextSubstitutor substitutor = new TextSubstitutor();

            DateTime now = DateTime.Now;
            IEnumerable<object> parameters = new List<object>
            {
                "World",
                now
            };

            string actual = substitutor.Substitute(template, parameters);
        }
    }
}
