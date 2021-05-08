using System;
using System.Collections.Generic;
using System.Threading;

namespace Wincubate.Threading.Module08
{
    public class PrimeHelper
    {
        // Naive prime factoring :-)
        public List<int> GetPrimeFactors(int n)
        {
            if (n < 2)
            {
                throw new ArgumentOutOfRangeException("Numbers less than 2 don't have prime factors");
            }

            List<int> result = new List<int>();

            int divisor = 2;

            while (divisor <= n)
            {
                if (n % divisor == 0)
                {
                    result.Add(divisor);
                    n /= divisor;
                }
                else
                {
                    divisor++;
                }
            }

            Random random = new Random();
            Thread.Sleep(2000 + random.Next(5000));

            return result;
        }
    }
}
