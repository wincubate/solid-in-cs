namespace Wincubate.Module1.Exceptions;

[Serializable]
public class StockException(
    string? message = null,
    Exception? inner = null
) : Exception(message, inner)
{
}
