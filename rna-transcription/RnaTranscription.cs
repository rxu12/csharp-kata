using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    private static readonly Dictionary<char, char> DnaRnaDict = new Dictionary<char, char>
    {
        ['G'] = 'C',
        ['C'] = 'G',
        ['T'] = 'A',
        ['A'] = 'U'
    };

    public static string ToRna(string nucleotide)
    {
        char[] rnaArr =  nucleotide.Select(dna => DnaRnaDict[dna]).ToArray();
        return new string(rnaArr);
    }
}