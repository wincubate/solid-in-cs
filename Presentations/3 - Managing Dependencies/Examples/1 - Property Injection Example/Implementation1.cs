using System;

namespace Wincubate.Module3.ManagingDependencies;

internal class Implementation1 : IDependency
{
    public void DoStuff()
    {
        Console.WriteLine( $"I am {nameof(Implementation1)}" );
    }
}
