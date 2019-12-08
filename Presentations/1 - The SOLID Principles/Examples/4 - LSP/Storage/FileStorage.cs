using System;
using System.IO;

namespace Wincubate.Solid.Module01
{
    class FileStorage : IStorage
    {
        public string GetDataAsString(string sourceFilePath)
        {
            try
            {
                return File.ReadAllText(sourceFilePath);
            }
            catch (Exception exception)
            {
                string message = $"Could not load from \"{sourceFilePath}\"";
                throw new StockStorageException(message, exception);
            }
        }

        public void StoreDataAsString(string destinationFilePath, string outputDataAsString)
        {
            try
            {
                File.WriteAllText(destinationFilePath, outputDataAsString);
            }
            catch (Exception exception)
            {
                string message = $"Could not write to \"{destinationFilePath}\"";
                throw new StockStorageException(message, exception);
            }
        }
    }
}
