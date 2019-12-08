using System;

namespace Cinema.Domain.Interfaces
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
}
