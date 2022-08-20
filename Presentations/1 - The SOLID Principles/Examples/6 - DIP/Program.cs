using System.Threading.Tasks;

namespace Wincubate.Module1
{
    static class Program
    {
        private const string Url = @"http://solid.wincubate.net/stockpositions.json";

        static async Task Main(string[] args)
        {
            //string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
            //string sourceFilePath = @"..\..\..\..\Files\StockPositions2.json";
            //string sourceFilePath = @"http://solid.wincubate.net/stockpositions.json";
            //string destinationFilePath = @"..\..\..\..\Files\Result.csv";
            //string destinationFilePath = @"..\..\..\..\Files\Result.json";
            //_writeStorage = new FileStorage( @"..\..\..\..\Files\StockPositions1.csv",@"..\..\..\..\Files\Result.json" );
            //_storage = new FileStorage();
            //_parser = new Parser();
            //_serializer = new CsvSerializer();

            StockAnalyzer analyzer = new StockAnalyzer(
                new WebStorage(Url),
                new ConsoleStorage(),
                new JsonParser(),
                new JsonSerializer()
            );
            await analyzer.ProcessAsync();
        }
    }
}
