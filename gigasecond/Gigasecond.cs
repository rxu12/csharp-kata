using System;

public static class Gigasecond
{
    private const int GigaSec = 1000000000;
    public static DateTime Add(DateTime moment) => moment.AddSeconds(GigaSec);
}