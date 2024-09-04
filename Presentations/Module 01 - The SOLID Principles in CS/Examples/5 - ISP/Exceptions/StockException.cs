namespace Wincubate.Module1;

[Serializable]
public class StockException(
    string? message = null,
    Exception? inner = null
) : Exception(message, inner)
{
}
