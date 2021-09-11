using System.Collections.Generic;

namespace CalculatorAPI.Logics
{
    public interface IMathUtilities
    {
        bool CheckPrime(decimal number);
        int SumOnlyPositiveIntegers(IEnumerable<int> numbers);
    }
}