using Wincubate.Module1;

string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
string destinationFilePath = @"..\..\..\..\Files\Result.csv";

StockAnalyzer analyzer = new();
await analyzer.ProcessAsync(sourceFilePath, destinationFilePath);
