using Wincubate.Module1;
using Wincubate.Module1.Exceptions;
using Wincubate.Module1.Formatters;
using Wincubate.Module1.Parsing;
using Wincubate.Module1.Storage.Sms;
using Wincubate.Module1.Storage.Web;

string Url = @"https://www.dotnet.coach/stockpositions.json";

//string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
//string sourceFilePath = @"..\..\..\..\Files\StockPositions2.json";
//string sourceFilePath = @"https://www.dotnet.coach/stockpositions.json";
//string destinationFilePath = @"..\..\..\..\Files\Result.csv";
//string destinationFilePath = @"..\..\..\..\Files\Result.json";
//_writeStorage = new FileStorage( @"..\..\..\..\Files\StockPositions1.csv",@"..\..\..\..\Files\Result.json" );
//_storage = new FileStorage();
//_parser = new Parser();
//_formatter = new CsvFormatter();

try
{
    StockAnalyzer analyzer = new(
        new WebStorage(Url),
        new TwilioSmsWriteStorage("+4512345678"),
        new JsonParser(),
        new JsonFormatter()
    );
    await analyzer.ProcessAsync();
}
catch (StockException exception)
{
    Console.WriteLine($"Unexpected error occurred: {exception.Message}");
}
