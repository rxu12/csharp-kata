using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var range = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        return range > 10 ? 0 : range > 5 ? 1 : range > 1 ? 5 : 10;
    }
}
