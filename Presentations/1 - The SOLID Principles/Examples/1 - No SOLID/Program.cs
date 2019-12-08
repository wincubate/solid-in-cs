using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
            string inputDataAsString = GetDataAsString(sourceFilePath);

            IEnumerable<StockPosition> stockPositions = Parse(inputDataAsString);

            IEnumerable<StockPosition> output = Compute(stockPositions);

            string outputDataAsString = SerializeData(output);

            string destinationFilePath = @"..\..\..\..\Files\Result.csv";
            StoreDataAsString(destinationFilePath, outputDataAsString);
        }

        static string GetDataAsString(string sourceFilePath)
        {
            return File.ReadAllText(sourceFilePath);
        }

        static void StoreDataAsString(string destinationFilePath, string outputDataAsString)
        {
            File.WriteAllText(destinationFilePath, outputDataAsString);
        }

        static IEnumerable<StockPosition> Parse(string dataAsString)
        {
            try
            {
                return dataAsString
                    .Split('\n', '\r', '\t')
                    .Where(s => string.IsNullOrWhiteSpace(s) == false)
                    .Select(line => line.Split(','))
                    .Select(parts => new StockPosition(
                        parts[0],
                        int.Parse(parts[1]))
                    )
                    .ToList()
                    ;
            }
            catch (Exception exception)
            {
                string message = $"Could not parse CSV string: \"{dataAsString}\"";
                throw new StockException(message, exception);
            }
        }

        static IEnumerable<StockPosition> Compute(IEnumerable<StockPosition> inputData)
        {
            return inputData
                .GroupBy(stockPosition => stockPosition.Ticker)
                .Select(group => new StockPosition(
                    group.Key,
                    group.Sum(stockPosition => stockPosition.Size))
                )
                .ToList()
                ;
        }

        static string SerializeData(IEnumerable<StockPosition> outputData)
        {
            IEnumerable<string> outputLines = outputData
                .Select(stockPosition => $"{stockPosition.Ticker},{stockPosition.Size}")
                ;
            return string.Join(Environment.NewLine, outputLines);
        }
    }
}
