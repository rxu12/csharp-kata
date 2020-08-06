using System;
using System.Linq;
public static class BeerSong
{
    private static string BottleIt(int qty)
    {
        return qty > 0 ?
        qty > 1 ? $"{qty} bottles"
            : $"{qty} bottle"
        : "no more bottles";
    }

    public static string Recite(int startBottles, int takeDown)
    {
        var start = startBottles >= takeDown ? startBottles - takeDown + 1 : 0;
        var increment = startBottles >= takeDown ? takeDown : startBottles + 1;
        Func<int, string> ItOrOne = (qty) => qty > 1 ? "one" : "it";

        var repeated = Enumerable.Range(start, increment)
        .Reverse()
        .Select((curr)
            => curr != 0 ?
            $"{BottleIt(curr)} of beer on the wall, {BottleIt(curr)} of beer.\n"
                + $"Take {ItOrOne(curr)} down and pass it around, {BottleIt(curr - 1)} of beer on the wall."
            : "No more bottles of beer on the wall, no more bottles of beer.\n"
                    + "Go to the store and buy some more, 99 bottles of beer on the wall.");

        return string.Join("\n\n", repeated);
    }
}