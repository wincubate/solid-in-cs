namespace Wincubate.Solid.Module01
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
            string sourceFilePath = @"..\..\..\..\Files\StockPositions2.json";
            //string destinationFilePath = @"..\..\..\..\Files\Result.csv";
            string destinationFilePath = @"..\..\..\..\Files\Result.json";

            StockAnalyzer analyzer = new StockAnalyzer();
            analyzer.Process(sourceFilePath, destinationFilePath);
        }
    }
}
