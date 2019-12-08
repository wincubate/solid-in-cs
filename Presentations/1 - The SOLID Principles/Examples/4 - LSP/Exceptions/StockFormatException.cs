using System;
using System.Runtime.Serialization;

namespace Wincubate.Solid.Module01
{
    [Serializable]
    public class StockFormatException : StockException
    {
        public StockFormatException(
            string message = null,
            Exception inner = null
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
}
