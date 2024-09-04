namespace Wincubate.Module1.Domain;

// Invariant: When TurnIgnitionKey() has been invoked, IsEngineRunning is true
public class Car
{
    public bool IsEngineRunning { get; protected set; }

    public Car()
    {
        IsEngineRunning = false;
    }

    public virtual void TurnIgnitionKey()
    {
        // ...

        IsEngineRunning = true;
    }
}
