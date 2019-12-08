using Cinema.Domain.Interfaces;
using System;

namespace Cinema.Domain
{
    public class DefaultTimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
