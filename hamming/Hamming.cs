using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException();
        var secondStrdChars = secondStrand.ToCharArray();
        return firstStrand.ToCharArray().Select((c, i) => c == secondStrdChars[i] ? 0 : 1).Sum();
    }
}