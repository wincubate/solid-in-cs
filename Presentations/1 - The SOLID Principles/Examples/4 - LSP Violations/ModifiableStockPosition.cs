using Wincubate.Module1.DomainLayer;

namespace Wincubate.Module1
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
