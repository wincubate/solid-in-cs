namespace Wincubate.Module1.Domain;

public record class StockPosition
{
    public string Ticker { get; protected set; }
    public int Size { get; protected set; }

    public override string ToString() => $"{Ticker} [{Size}]";

    public StockPosition(string ticker, int size)
    {
        Ticker = ticker;
        Size = size;
    }
}
