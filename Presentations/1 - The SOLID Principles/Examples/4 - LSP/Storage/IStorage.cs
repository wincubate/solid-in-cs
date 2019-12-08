namespace Wincubate.Solid.Module01
{
    interface IStorage
    {
        string GetDataAsString(string sourceFilePath);
        void StoreDataAsString(string destinationFilePath, string outputDataAsString);
    }
}
