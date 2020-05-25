using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException();

        int step = 0;
        int stepVal = number;

        while (stepVal != 1)
        {
            if (stepVal % 2 == 0) stepVal = stepVal / 2;
            else stepVal = 3 * stepVal + 1;
            step++;
        }

        return step;
    }
}