using Admin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin.Domain
{
    public class TextSubstitutor
    {
        public string Substitute(
            MessageTemplate messageTemplate,
            IEnumerable<object> parameters)
        {
            string messageContents = string.Empty;
            try
            {
                messageContents = string.Format(
                    messageTemplate.BodyTemplate,
                    parameters?.ToArray() ?? new object[0]);
            }
            catch (FormatException exception)
            {
                throw new AdminException(
                    $"Could not substitute the parameters into the message template contents " +
                    $"\"{messageTemplate.BodyTemplate}\" [Id:{messageTemplate.Id}]",
                    exception,
                    AdminExceptionReason.Messaging
                );
            }

            return messageContents;
        }
    }
}
