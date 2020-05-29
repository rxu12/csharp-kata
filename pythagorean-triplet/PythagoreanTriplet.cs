using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (int a = 1; a < sum / 3; a++)
        {
            for (int b = a + 1; b <= (sum - a) / 2; b++) // 4 <= (12 - 3) / 2
            {
                if (a * a + b * b == Math.Pow(sum - b - a, 2))
                    yield return (a, b, sum - b - a);
            }
        }
    }
}