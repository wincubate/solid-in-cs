using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

class ElectricCar : Car
{
    public bool IsEnginePreparedToRun { get; private set; }

    public ElectricCar()
    {
        IsEnginePreparedToRun = false;
    }

    public override void TurnIgnitionKey()
    {
        IsEnginePreparedToRun = true;
    }

    public void PressGasPedal()
    {
        if (IsEnginePreparedToRun)
        {
            IsEngineRunning = true;
        }
    }
}
