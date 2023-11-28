using System.Runtime.Serialization;

namespace Wincubate.Module1;

[Serializable]
public class StockException : Exception
{
    public StockException(
        string? message = null,
        Exception? inner = null
    )
        : base(message, inner)
    {
    }

    protected StockException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}
