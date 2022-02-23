using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
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
}
