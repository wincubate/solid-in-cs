using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class Program
    {
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

            IReadStorage readStorage = new WebStorage(@"http://solid.wincubate.net/stockpositions.json");
            IWriteStorage writeStorage = new ConsoleStorage();
            IParser parser = new JsonParser();
            ISerializer serializer = new JsonSerializer();

            StockAnalyzer analyzer = new StockAnalyzer(
                readStorage, writeStorage, parser, serializer
            );
            await analyzer.ProcessAsync();
        }
    }
}
