using Admin.Domain.Interfaces;
using System.Collections.Generic;

namespace Admin.Domain
{
    /// <summary>
    /// Implementation class for messages to be resolved
    /// and sent using the <see cref="Messenger"/>.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets the recipient of the <see cref="Message"/>.
        /// </summary>
        public User Recipient { get; set; }

        /// <summary>
        /// Gets or sets the Id of the <see cref="MessageTemplate"/> to use.
        /// </summary>
        public string MessageTemplateKind { get; set; }

        /// <summary>
        /// Gets or sets the Culture of the <see cref="MessageTemplate"/> to use.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the parameters to be substituted into the <see cref="MessageTemplate"/>.
        /// </summary>
        public IEnumerable<object> Parameters { get; set; }
    }
}
