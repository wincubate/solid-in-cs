using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

interface IParser
{
    IEnumerable<StockPosition> Parse(string dataAsString);
}
