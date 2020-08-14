using System;
using System.Linq;
using System.Collections.Generic;

public class Robot
{
    private string name;
    private static readonly Random random = new Random();
    private static HashSet<string> namePool = new HashSet<string>();

    public Robot()
    {
        name = MakeName();
    }

    private string MakeName()
    {
        string name;
        do
        {
            var letters = Enumerable.Range(0, 2).Aggregate("", (acc, i) => acc + (char)('A' + random.Next(0, 26)));
            var numbers = Enumerable.Range(0, 3).Aggregate("", (acc, i) => acc + random.Next(0, 9).ToString());
            name = letters + numbers;
        }
        while (!namePool.Add(name));
        return name;
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public void Reset()
    {
        name = MakeName();
    }
}