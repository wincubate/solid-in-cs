using System;
using System.Runtime.Serialization;

namespace Admin.Domain.Interfaces
{
    /// <summary>
    /// Custom exception class for errors.
    /// </summary>
    [Serializable]
    public class AdminException : Exception, ISerializable
    {
        /// <summary>
        /// Reason code for cinema admin error.
        /// </summary>
        public AdminExceptionReason Reason { get; }

        /// <summary>
        /// Creates a new instance of <see cref="AdminException"/>
        /// with reason code specified by <paramref name="reason"/> and
        /// inner exception specified by <paramref name="inner"/>.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        /// <param name="reason">Cinema Admin reason code.</param>
        public AdminException(
            string message = null,
            Exception inner = null,
            AdminExceptionReason reason = AdminExceptionReason.InternalError)
            : base(message, inner)
        {
            Reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminException"/>
        /// class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds
        /// the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that
        /// contains contextual information about the source or destination.
        /// </param>
        protected AdminException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
