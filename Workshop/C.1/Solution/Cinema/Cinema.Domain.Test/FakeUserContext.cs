using Cinema.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Domain.Test
{
    internal class FakeUserContext : IUserContext
    {
        private readonly IEnumerable<UserRole> _userRoles;

        public FakeUserContext( params UserRole[] userRoles )
        {
            _userRoles = userRoles;
        }

        public bool IsInRole(UserRole role) => _userRoles.Contains(role);
    }
}
