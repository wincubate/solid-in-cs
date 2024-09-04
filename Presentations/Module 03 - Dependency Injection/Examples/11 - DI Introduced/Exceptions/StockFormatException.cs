namespace Wincubate.Module1;

[Serializable]
public class StockFormatException(
    string? message = null,
    Exception? inner = null
    ) : StockException(message, inner)
{
}
