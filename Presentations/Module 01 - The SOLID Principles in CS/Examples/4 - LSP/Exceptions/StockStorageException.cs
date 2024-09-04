namespace Wincubate.Module1;

[Serializable]
public class StockStorageException(
    string? message = null,
    Exception? inner = null
) : StockException(message, inner)
{
}
