using System;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException("Must be positive integer!");

        int sumOfFactors = 0;

        for (int i = 1; i < number; i++) if (number % i == 0) sumOfFactors += i;
 
        return sumOfFactors > number ? Classification.Abundant
            : sumOfFactors < number ? Classification.Deficient
            : Classification.Perfect;
    }
}
