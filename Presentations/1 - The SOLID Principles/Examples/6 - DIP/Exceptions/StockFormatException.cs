using System.Runtime.Serialization;

namespace Wincubate.Module1;

[Serializable]
public class StockFormatException : StockException
{
    public StockFormatException(
        string? message = null,
        Exception? inner = null
    )
        : base(message, inner)
    {
    }

    protected StockFormatException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}
