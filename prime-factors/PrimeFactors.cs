using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        long remainder = number;
        long divisor = 2;
        List<long> divisors = new List<long>();

        while (remainder != 1L)
        {
            if (remainder % divisor == 0)
            {
                divisors.Add(divisor);
                remainder /= divisor;
            }
            else
            {
                divisor++;
            }
        }

        return divisors.ToArray();
    }
}