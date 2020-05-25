using System;
using System.Collections;
using System.Collections.Generic;

public static class Pangram
{
    private static readonly HashSet<char> AlphabetSet = populateAlphabet();

    private static HashSet<char> populateAlphabet()
    {
        const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        char[] alphaSubStr = Alphabet.ToCharArray();
        return new HashSet<char>(alphaSubStr);
    }

    public static bool IsPangram(string input)
    {
        var result = new HashSet<char>();
        foreach (char e in input.ToLower().ToCharArray())
        {
            if(AlphabetSet.Contains(e)) result.Add(e);
        }
        return result.Count == 26;
    }
}
