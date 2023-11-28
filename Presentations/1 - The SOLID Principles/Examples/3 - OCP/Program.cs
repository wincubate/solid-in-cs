using Wincubate.Module1;

string sourceFilePath = @"..\..\..\..\Files\StockPositions2.json";
string destinationFilePath = @"..\..\..\..\Files\Result.json";

StockAnalyzer analyzer = new();
await analyzer.ProcessAsync(sourceFilePath, destinationFilePath);
