using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
            string destinationFilePath = @"..\..\..\..\Files\Result.csv";

            StockAnalyzer analyzer = new StockAnalyzer();
            await analyzer.ProcessAsync(sourceFilePath, destinationFilePath);
        }
    }
}
