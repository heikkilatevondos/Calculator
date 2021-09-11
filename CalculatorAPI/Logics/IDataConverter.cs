using System.Collections.Generic;

namespace CalculatorAPI.Logics
{
    public interface IDataConverter
    {
        IEnumerable<int> ConvertCSVStringToInts(string csvNumbers);
    }
}