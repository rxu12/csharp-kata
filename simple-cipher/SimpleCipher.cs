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

/***
using System.Linq;
using System.Security.Cryptography;

public class SimpleCipher
{
    private string _key;

    private const int generatedKeyLength = 100;
    private const int numberOfLettersInAlphabet = 26;

    public SimpleCipher(string key = null) => Key = key;
    
    public string Key 
    {
        get => _key ??= GenerateRandomKey();
        private set => _key = value;
    }

    public string Encode(string plaintext) =>
        new string(plaintext.Select((c, i) => EncodeChar(c, Key[i % Key.Length])).ToArray());

    public string Decode(string ciphertext) =>
        new string(ciphertext.Select((c, i) => DecodeChar(c, Key[i % Key.Length])).ToArray());

    private static string GenerateRandomKey() =>
        new string(Enumerable.Repeat(GenerateRandomLetter(), generatedKeyLength).ToArray());

    private static char GenerateRandomLetter() =>
        (char)(RandomNumberGenerator.GetInt32(numberOfLettersInAlphabet) + (int)'a');

    private static char EncodeChar(char toEncode, char key) => NormalizeChar((int)toEncode + ShiftAmount(key));
    private static char DecodeChar(char toDecode, char key) => NormalizeChar((int)toDecode - ShiftAmount(key));
    private static int  ShiftAmount(char key) => (int)key - (int)'a';

    private static char NormalizeChar(int ascii) =>
        ascii < (int)'a' ? (char)(ascii + numberOfLettersInAlphabet) :
        ascii > (int)'z' ? (char)(ascii - numberOfLettersInAlphabet) :
        (char)ascii;
}*/