namespace Admin.Domain.Interfaces
{
    /// <summary>
    /// POCO class capturing a single message template definition
    /// from the underlying database.
    /// </summary>
    public class MessageTemplate
    {
        /// <summary>
        /// Gets or sets the Id of the <see cref="MessageTemplate"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the kind of the <see cref="MessageTemplate"/>.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the culture identifier of the
        /// <see cref="MessageTemplate"/>.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the Subject text of the
        /// <see cref="MessageTemplate"/>.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the Body Template of the
        /// <see cref="MessageTemplate"/>.
        /// </summary>
        public string BodyTemplate { get; set; }

        /// <summary>
        /// Provides a string representation of the
        /// <see cref="MessageTemplate"/>.
        /// </summary>
        /// <returns>String representation of the current
        /// <see cref="MessageTemplate"/>.</returns>
        public override string ToString() => $"{Id}\t{Culture}\t{BodyTemplate}";
    }
}
