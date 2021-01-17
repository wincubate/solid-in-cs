namespace Admin.Domain.Interfaces
{
    /// <summary>
    /// Reason code for use with <see cref="AdminException"/>.
    /// </summary>
    public enum AdminExceptionReason
    {
        /// <summary>
        /// Internal error performing message-related activities.
        /// </summary>
        InternalError,

        /// <summary>
        /// Could not locate message template with specified id.
        /// Could not substitute parameters into the message template.
        /// General error occurred sending a message.
        /// </summary>
        Messaging,

        /// <summary>
        /// Error occurred sending an email.
        /// </summary>
        EmailError,

        /// <summary>
        /// Error occurred sending an SMS.
        /// </summary>
        SmsError
    }
}
