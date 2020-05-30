using System;
using System.Collections.Generic;
using System.Linq;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        List<int[]> result = new List<int[]>();
        return Enumerable.Range(1, rows)
            .Aggregate(result, CalcRow);
    }

    private static List<int[]> CalcRow(List<int[]> acc, int next)
    {
        if (next == 1)
        {
            acc.Add(new int[] { next });
        }
        else
        {
            int[] prevRow = acc[acc.Count - 1];
            int[] currRow = Enumerable.Range(0, next)
                .Select((e) => (e == prevRow.Length ? 0 : prevRow[e])
                    + (e == 0 ? e : prevRow[e - 1]))
                .ToArray();
            acc.Add(currRow);
        }
        return acc;
    }
}


// Solution 2
//using System;
//using System.Collections.Generic;

//public static class PascalsTriangle
//{
//    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
//    {
//        var triangle = new List<List<int>>();
//        for (int i = 0; i < rows; i++)
//        {
//            triangle.Add(new List<int>());
//            triangle[i].Add(1);
//            for (int k = 1; k <= i; k++)
//            {
//                if (k == i) triangle[i].Add(1);
//                else triangle[i].Add(triangle[i - 1][k - 1] + triangle[i - 1][k]);
//            }

//        }
//        return triangle;
//    }

//}