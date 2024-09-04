using Wincubate.Module1.Domain;

namespace Wincubate.Module1.Parsing;

interface IParser
{
    IEnumerable<StockPosition> Parse(string dataAsString);
}
