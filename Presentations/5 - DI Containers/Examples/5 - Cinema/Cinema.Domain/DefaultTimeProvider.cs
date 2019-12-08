using Cinema.Domain.Interfaces;
using System;
using System.Diagnostics;

namespace Cinema.Domain
{
    public class DefaultTimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.Now;

        public DefaultTimeProvider()
        {
            Debug.WriteLine($"{nameof(DefaultTimeProvider)} created");
        }
    }
}
