using System;
using System.Linq;

public static class House
{
    private static readonly string[] RHYME = {
        "the house that Jack built",
        "the malt that lay in",
        "the rat that ate",
        "the cat that killed",
        "the dog that worried",
        "the cow with the crumpled horn that tossed",
        "the maiden all forlorn that milked",
        "the man all tattered and torn that kissed",
        "the priest all shaven and shorn that married",
        "the rooster that crowed in the morn that woke",
        "the farmer sowing his corn that kept",
        "the horse and the hound and the horn that belonged to"
    };

    public static string Recite(int verseNumber)
    {
        return $"This is {string.Join(" ", RHYME.Take(verseNumber).Reverse())}.";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return string.Join("\n", Enumerable
            .Range(startVerse, endVerse - startVerse + 1)
            .Select(n => Recite(n)));
    }
}