using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        string reversed = "";
        foreach (char c in input)
        {
            reversed = c + reversed;
        }
        return reversed;
    }
}