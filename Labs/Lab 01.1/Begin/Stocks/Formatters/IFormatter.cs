using Wincubate.Module1.Domain;

namespace Wincubate.Module1.Formatters;

interface IFormatter
{
    string FormatData(IEnumerable<StockPosition> outputData);
}
