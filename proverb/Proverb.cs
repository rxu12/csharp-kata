using System;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        return subjects
        .Select((wd, i) => i != subjects.Length - 1
            ? $"For want of a {wd} the {subjects[i + 1]} was lost."
            : $"And all for the want of a {subjects[0]}.").ToArray();
    }
}