using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Logics
{
    public class MathUtilities : IMathUtilities
    {
        public bool CheckPrime(decimal number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            if (i == number)
            {
                return true;
            }
            return false;
        }

        public int SumOnlyPositiveIntegers(IEnumerable<int> numbers)
        {
            return numbers.Where(x => x > 0).Sum();
        }

    }
}
