using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class ModifiableStockPosition : StockPosition
    {
        public ModifiableStockPosition(string ticker, int size) : base(ticker, size)
        {
        }

        public void ModifyTicker(string newTicker)
        {
            Ticker = newTicker;
        }
    }
}
