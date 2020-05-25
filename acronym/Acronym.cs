using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string[] initials = phrase
            .Split(new char[] { ' ', '-', '_' })
            .Select(str => str == "" ? string.Empty : str[0].ToString())
            .ToArray();
        return String.Join("", initials).ToUpper();
    }
}