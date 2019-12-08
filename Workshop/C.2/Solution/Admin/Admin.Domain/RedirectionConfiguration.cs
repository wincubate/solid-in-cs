namespace Admin.Domain
{
    public class RedirectionConfiguration
    {
        public string Email { get; }
        public string Phone { get; }

        public RedirectionConfiguration( string email = null, string phone = null )
        {
            Email = email;
            Phone = phone;
        }
    }
}
