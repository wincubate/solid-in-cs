using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //string sourceFilePath = @"..\..\..\Files\StockPositions1.csv";
            //string sourceFilePath = @"..\..\..\Files\StockPositions2.json";
            //string sourceFilePath = @"https://www.dotnet.coach/stockpositions.json";
            //string destinationFilePath = @"..\..\..\Files\Result.csv";
            //string destinationFilePath = @"..\..\..\Files\Result.json";
            //_writeStorage = new FileStorage( @"..\..\..\Files\StockPositions1.csv",@"..\..\..\Files\Result.json" );

            StockAnalyzer analyzer = new StockAnalyzer(
                new WebStorage(@"https://www.dotnet.coach/stockpositions.json"),
                new CompositeWriteStorage(
                    new ConsoleStorage(),
                    new TwilioSmsTransmissionStorage("+4522123631")
                ),
                new JsonParser(),
                new JsonSerializer()
            );
            await analyzer.ProcessAsync();
        }
    }
}
