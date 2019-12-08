using System;
using System.Runtime.Serialization;

namespace Wincubate.Solid.Module01
{
    [Serializable]
    public class StockException : Exception, ISerializable
    {
        public StockException(
            string message = null,
            Exception inner = null
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
}
