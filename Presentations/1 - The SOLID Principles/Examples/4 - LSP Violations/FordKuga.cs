using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class FordKuga : Car
    {
        public bool IsEnginePreparedToRun { get; private set; }

        public FordKuga()
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
