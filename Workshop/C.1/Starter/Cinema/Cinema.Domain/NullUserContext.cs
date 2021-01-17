using Cinema.Domain.Interfaces;

namespace Cinema.Domain
{
    public class NullUserContext : IUserContext
    {
        public bool IsInRole(UserRole role) => false;
    }
}
