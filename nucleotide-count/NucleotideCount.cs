using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var nucDict = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };

        foreach (char c in sequence)
        {
            int scr = 0;
            if (nucDict.TryGetValue(c, out scr))
            {
                nucDict[c] = ++scr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        return nucDict;
    }
}