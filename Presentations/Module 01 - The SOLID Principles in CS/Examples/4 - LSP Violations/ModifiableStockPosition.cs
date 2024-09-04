using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

record class ModifiableStockPosition : StockPosition
{
    public ModifiableStockPosition(string ticker, int size) : base(ticker, size)
    {
    }

    public void ModifyTicker(string newTicker)
    {
        Ticker = newTicker;
    }
}
