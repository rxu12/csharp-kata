using System;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int source = number;
        List<int> digits = new List<int>();
        while (source  > 0)
        {
            int digit = source % 10;
            source /= 10;
            digits.Add(digit);
        }
        return digits.Aggregate(0,
            (acc, digit) => (int)(acc + Math.Pow(digit, digits.Count))) == number;
    }
}