using System;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if(numbers.Length == 0 || sliceLength <= 0 || sliceLength > numbers.Length)
            throw new ArgumentException();

        return numbers
            .Select((d, i) => i + sliceLength > numbers.Length
                ? null
                : numbers[i..(i + sliceLength)])
            .Where(e => e != null)
            .ToArray();
    }
}