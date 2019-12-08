namespace Admin.Domain.Interfaces
{
    /// <summary>
    /// Class describing a single user recipient of <see cref="Message"/> instances.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets the name of the recipient.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the phone number of the user, if specified.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// Gets the preferred culture string the user, if specified.
        /// </summary>
        public string PreferredCulture { get; }

        /// <summary>
        /// Create a new <see cref="User"/> from the specified <paramref name="name"/>,
        /// <paramref name="email"/>, <paramref name="phone"/>, and <paramref name="preferredCulture"/>
        /// parameters.
        /// </summary>
        public User( string name, string email, string phone, string preferredCulture = "en" )
        {
            Name = name;
            Email = email;
            Phone = phone;
            PreferredCulture = preferredCulture;
        }
    }
}
