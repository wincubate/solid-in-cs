namespace Wincubate.Solid.Module01
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
            string destinationFilePath = @"..\..\..\..\Files\Result.csv";

            StockAnalyzer analyzer = new StockAnalyzer();
            analyzer.Process(sourceFilePath, destinationFilePath);
        }
    }
}
