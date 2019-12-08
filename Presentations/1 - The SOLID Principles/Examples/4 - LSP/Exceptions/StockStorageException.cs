using System;
using System.Runtime.Serialization;

namespace Wincubate.Solid.Module01
{
    [Serializable]
    public class StockStorageException : StockException
    {
        public StockStorageException(
            string message = null,
            Exception inner = null
        )
            : base(message, inner)
        {
        }

        protected StockStorageException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
