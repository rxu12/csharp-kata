using System;

public static class Leap
{
    public static bool IsLeapYear(int yr) => yr % 4 == 0 && (yr % 100 != 0 || yr % 400 == 0);
}