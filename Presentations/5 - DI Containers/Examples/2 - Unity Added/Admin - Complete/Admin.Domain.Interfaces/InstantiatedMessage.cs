using System;

namespace Admin.Domain.Interfaces
{
    /// <summary>
    /// Class for instantiated instances, i.e. it has
    /// already been resolved and substituted from a
    /// <see cref="Message"/>.
    /// </summary>
    public class InstantiatedMessage
    {
        /// <summary>
        /// Unique application-identifier for message instance.
        /// </summary>
        public Guid InstanceId { get; }

        /// <summary>
        /// Message string subject.
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// Message string body.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Creates a new <see cref="InstantiatedMessage"/> with
        /// the message contents specified in <paramref name="body"/>.
        /// </summary>
        /// <param name="subject">Message string subject.</param>
        /// <param name="body">Message string body.</param>
        public InstantiatedMessage(string subject, string body)
        {
            Subject = subject;
            Body = body;
            InstanceId = Guid.NewGuid();
        }
    }
}
