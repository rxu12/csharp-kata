using System;
using System.Linq;
using System.Collections.Generic;

public static class ScrabbleScore
{
    private static readonly Dictionary<string, int> ScoreDict
        = new Dictionary<string, int>
        {
            {"A,E,I,O,U,L,N,R,S,T", 1},
            {"D,G", 2},
            {"B,C,M,P", 3},
            {"F,H,V,W,Y", 4},
            {"K", 5},
            {"J,X", 8},
            {"Q,Z", 10 }
        };

    private static readonly Dictionary<char, int> ScoreMap
        = ScoreDict
            .Aggregate(new Dictionary<char, int> { }, populateScore);

    private static Dictionary<char, int> populateScore
        (Dictionary<char, int> scoredict, KeyValuePair<string, int> pair)
    {
        pair.Key.Split(new char[] {','}).ToList().ForEach(e => scoredict.Add(e[0], pair.Value));
        return scoredict;
    }

    public static int Score(string input)
    {
        return input.ToUpper().Sum(curr => ScoreMap[curr]);
    }
}