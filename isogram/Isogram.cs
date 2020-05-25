using System;
using System.Collections.Generic;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        HashSet<char> letters = new HashSet<char>(new char[] { });
        foreach (char e in word.ToLower())
        {
            if (letters.Contains(e))
            {
                return false;
            }
            if (e != '-' && e != ' ')
            {
                
                letters.Add(e);
            }
        }
        return true;
    }
}
