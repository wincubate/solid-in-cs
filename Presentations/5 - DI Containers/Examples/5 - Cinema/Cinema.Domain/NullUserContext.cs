using Cinema.Domain.Interfaces;
using System.Diagnostics;

namespace Cinema.Domain
{
    public class NullUserContext : IUserContext
    {
        public bool IsInRole(UserRole role) => false;

        public NullUserContext()
        {
            Debug.WriteLine($"{nameof(NullUserContext)} created");
        }
    }
}
