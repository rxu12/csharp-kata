using System.Collections.Generic;
using System.Linq;

public static class ResistorColor
{
    private static readonly Dictionary<string, int> ColorMap = Colors().Select((v, i) => (Key: i, Value: v)).ToDictionary(o => o.Value, o => o.Key);

    public static int ColorCode(string color) => ColorMap[color];

    public static string[] Colors() => new string[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
}