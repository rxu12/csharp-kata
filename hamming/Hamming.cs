using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException();
        return Enumerable.Range(0, firstStrand.Length)
        .Select(i => firstStrand[i] == secondStrand[i] ? 0 : 1)
        .Sum();
    }
}