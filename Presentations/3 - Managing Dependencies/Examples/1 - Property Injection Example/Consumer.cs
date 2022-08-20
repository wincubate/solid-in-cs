namespace Wincubate.Module3.ManagingDependencies; 

public class Consumer
{
    public IDependency Dependency { get; set; }

    public void UseDependency()
    {
        Dependency.DoStuff();
    }
}
