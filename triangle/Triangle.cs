using System;
using System.Collections.Generic;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (!isTriangle(side1, side2, side3)) return false;
        return !IsIsosceles(side1, side2, side3) && !IsEquilateral(side1, side2, side3);
    }

    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        if (!isTriangle(side1, side2, side3)) return false;
        if (side1 == side2 || side1 == side3) return true;
        else if (side2 == side3) return true;
        return false;
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        if (!isTriangle(side1, side2, side3)) return false;
        var avgSide = (side1 + side2 + side3) / 3;
        return avgSide == side1 && side1 == side2;
    }

    private static bool isTriangle(double side1, double side2, double side3, int counter = 0)
    {
        if (counter == 3) return true;
        return side1 - side2 - side3 < 0 ? isTriangle(side2, side3, side1, ++counter) : false;
    }
}