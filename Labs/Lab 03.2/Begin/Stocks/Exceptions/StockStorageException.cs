namespace Wincubate.Module1.Exceptions;

[Serializable]
public class StockStorageException(
    string? message = null,
    Exception? inner = null
) : StockException(message, inner)
{
}
