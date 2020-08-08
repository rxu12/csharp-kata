using System;
using System.Linq;

public class SimpleCipher
{
    private int[] keyShift;
    private static readonly int ASCII_ALPHA = (int)'a';

    public SimpleCipher(string key = "abcdefghijklmnopqrstuvwxyz")
    {
        Key = key;
        keyShift = new int[key.Length];
        for (int i = 0; i < key.Length; i++)
        {
            keyShift[i] = (int)key[i] - ASCII_ALPHA;
        }
    }

    public string Key { get; }

    private char encodeChar(char c, int i)
    {
        var r = i % keyShift.Length;
        int shiftedPos = keyShift[r] + (int)c;
        return (char)((shiftedPos - ASCII_ALPHA) % 26 + ASCII_ALPHA);
    }

    private char decodeChar(char c, int i)
    {
        var r = i % keyShift.Length;
        int shift = (int)c - keyShift[r];
        int posNonShifted = shift - ASCII_ALPHA < 0 ? 26 + shift : shift;
        return (char)posNonShifted;
    }

    private string Translate(string content, Func<char, int, char> worker)
    {
        return string.Join("", content.Select(worker));
    }

    public string Encode(string plaintext)
    {
        return Translate(plaintext, encodeChar);
    }

    public string Decode(string ciphertext)
    {
        return Translate(ciphertext, decodeChar);
    }
}