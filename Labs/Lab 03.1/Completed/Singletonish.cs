class Singletonish : ISingletonish
{
    public Singletonish()
    {
        Console.WriteLine($"Creating instance of {nameof(Singletonish)}");
    }

    public void DoStuff()
    {
        Console.WriteLine("Doing singletonish stuff...");
    }
}
