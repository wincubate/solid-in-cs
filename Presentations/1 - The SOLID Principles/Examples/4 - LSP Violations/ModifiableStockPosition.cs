using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class ModifiableStockPosition : StockPosition
    {
        public ModifiableStockPosition(string ticker, int size) : base(ticker, size)
        {
        }

        public void ModifyTicker( string newTicker )
        {
            Ticker = newTicker;
        }
    }
}
