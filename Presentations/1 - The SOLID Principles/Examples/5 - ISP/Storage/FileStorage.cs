using System;
using System.IO;

namespace Wincubate.Solid.Module01
{
    class FileStorage : IStorage
    {
        public string SourcePath { get; }
        public string DestinationPath { get; }

        public FileStorage( string sourcePath, string destinationPath )
        {
            SourcePath = sourcePath;
            DestinationPath = destinationPath;
        }

        public string GetDataAsString()
        {
            try
            {
                return File.ReadAllText(SourcePath);
            }
            catch (Exception exception)
            {
                string message = $"Could not load from \"{SourcePath}\"";
                throw new StockStorageException(message, exception);
            }
        }

        public void StoreDataAsString(string outputDataAsString)
        {
            try
            {
                File.WriteAllText(DestinationPath, outputDataAsString);
            }
            catch (Exception exception)
            {
                string message = $"Could not write to \"{DestinationPath}\"";
                throw new StockStorageException(message, exception);
            }
        }
    }
}
