using Cinema.Domain.Interfaces;
using System;

namespace Cinema.Domain.Test
{
    internal class ConstantTimeProvider : ITimeProvider
    {
        public DateTime Now { get; }

        public ConstantTimeProvider( DateTime dateTime )
        {
            Now = dateTime;
        }
    }
}
