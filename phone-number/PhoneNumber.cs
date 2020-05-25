using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string digits = Regex
            .Replace(phoneNumber, @"[a-zA-Z\+\(\)\-\s@:!.]", "");

        if (digits.Length < 10 || digits.Length > 11)
            throw new ArgumentException();

        if (digits.Length == 11 && digits[0] != '1')
            throw new ArgumentException();

        char areaCodeChar = digits[^10];

        if (areaCodeChar == '1' || areaCodeChar == '0')
            throw new ArgumentException();

        char exchangeCodeChar = digits[^7];

        if (exchangeCodeChar == '1' || exchangeCodeChar == '0')
            throw new ArgumentException();

        return digits[^10..];
    }
}

/**
using System;
using System.Linq;

namespace PhoneNumber
{
    public static class PhoneNumber
    {
        public static string Clean(string phoneNumber)
        {
            var cleaned = phoneNumber.Where(c => c >= '0' && c <= '9')
                .Aggregate("",
                    (current,
                        c) => current + c);
            if (cleaned.Length < 10 ||
                cleaned.Length == 11 && cleaned[0] != '1' ||
                cleaned[^10] < '2' ||
                cleaned[^7] < '2')
            {
                throw new ArgumentException();
            }

            return cleaned[^10..];
        }
    }
}
*/
