using System;

namespace Wincubate.Module3.ManagingDependencies;

internal class Implementation2 : IDependency
{
    public void DoStuff()
    {
        Console.WriteLine($"I am {nameof(Implementation2)}");
    }
}
