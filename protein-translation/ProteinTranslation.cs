using System;
using System.Linq;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string[]> ProteinsDict = new Dictionary<string, string[]>
    {
        ["AU"] = new[] { "Methionine" },
        ["UC"] = new[] { "Serine" },
        ["UU"] = new[] { "Phenylalanine", "Leucine" },
        ["UA"] = new[] { "Tyrosine", "STOP" },
        ["UG"] = new[] { "Cysteine", "Cysteine", "STOP", "Tryptophan" }
    };

    private static string NucToProtein(char nuc, string[] proteins)
    {
        if (proteins.Length == 1) return proteins[0];
        return nuc switch
        {
            'U' => proteins[0],
            'C' => proteins.Length > 2 ? proteins[1] : proteins[0],
            'A' => proteins.Length > 2 ? proteins[2] : proteins[1],
            'G' => proteins.Length > 2 ? proteins[3] : proteins[1]
        };
    }
    public static string[] Proteins(string strand)
    {
        var result = new List<string> { };
        int cursor = 0;

        while (cursor < strand.Length)
        {
            string triplet = strand.Substring(cursor, 3);
            cursor += 3;
            var protein = NucToProtein(triplet[2], ProteinsDict[triplet.Substring(0, 2)]);
            if (protein == "STOP") break;
            result.Add(protein);
        }

        return result.ToArray();
    }
}