using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Logics
{
    public class DataConverter : IDataConverter
    {
        public IEnumerable<int> ConvertCSVStringToInts(string csvNumbers)
        {
            if (csvNumbers == null)
            {
                throw new ArgumentNullException("csvNumbers parameter cannot be null");
            }

            return csvNumbers.Split(",").Select(x => int.Parse(x));
        }

    }
}
