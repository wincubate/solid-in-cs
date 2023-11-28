using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

interface IFormatter
{
    string FormatData(IEnumerable<StockPosition> outputData);
}
