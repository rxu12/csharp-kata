using System;
using System.Collections.Generic;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1
            || outputBase <= 1
            || inputDigits.Any(d => d < 0 || d >= inputBase))
            throw new ArgumentException();

        int inBase10 = toBase10(inputBase, inputDigits);

        return fromBase10(inBase10, outputBase);
    }

    private static int[] fromBase10(int inBase10, int outputBase)
    {
        int next = inBase10;
        List<int> output = new List<int>();

        while (next / outputBase != 0)
        {
            output.Add(next % outputBase);
            next /= outputBase;
        }

        output.Add(next);
        output.Reverse();
        return output.ToArray();
    }

    private static int toBase10(int inputBase, int[] inputDigits)
    {
        int n = inputDigits.Length;

        return inputDigits
            .Select((d, i) => d * Math.Pow(inputBase, n - i - 1))
            .Select(Convert.ToInt32)
            .Sum();
    }
}