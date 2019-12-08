using System.IO;

namespace Wincubate.Solid.Module01
{
    class FileStorage : IStorage
    {
        public string GetDataAsString(string sourceFilePath)
        {
            return File.ReadAllText(sourceFilePath);
        }

        public void StoreDataAsString(string destinationFilePath, string outputDataAsString)
        {
            File.WriteAllText(destinationFilePath, outputDataAsString);
        }
    }
}
