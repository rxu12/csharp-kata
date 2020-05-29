using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span < 0 || span > digits.Length)
            throw new ArgumentException();

        if (span == 0 || digits == "") return 1;

        if(!new Regex(@"^[0-9\s]+$").Match(digits).Success)
            throw new ArgumentException();

        Func<char, int, int> calcProduct = (c, i)
            => i + span <= digits.Length ?
                digits.Substring(i, span)
                .Aggregate(1, (acc, curr) => acc * (curr - '0')) : 0;


        return digits
            .Select(calcProduct)
            .Max();
    }
}