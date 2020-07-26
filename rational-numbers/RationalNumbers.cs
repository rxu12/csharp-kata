using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        double d = Math.Pow(realNumber, r._numerator);
        return Math.Pow(d, 1.0 / r._denorminator);
    }
}

public struct RationalNumber
{
    public double value;
    public int _numerator;
    public int _denorminator;

    public RationalNumber(int numerator, int denominator)
    {
        value = numerator / denominator;
        _numerator = numerator / gcd(numerator, denominator);
        _denorminator = denominator / gcd(numerator, denominator);
    }

    private static int gcd(int n1, int n2)
    {
        if (n2 == 0)
        {
            return n1;
        }
        else
        {
            return gcd(n2, n1 % n2);
        }
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        int numeratorOfSum = r1._numerator * r2._denorminator + r2._numerator * r1._denorminator;
        int denominatorOfSum = r1._denorminator * r2._denorminator;
        return new RationalNumber(numeratorOfSum, denominatorOfSum);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int numeratorOfDiff = r1._numerator * r2._denorminator - r1._denorminator * r2._numerator;
        int denorminatorOfDiff = r1._denorminator * r2._denorminator;
        return new RationalNumber(numeratorOfDiff, denorminatorOfDiff);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1._numerator * r2._numerator, r1._denorminator * r2._denorminator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1._numerator * r2._denorminator, r1._denorminator * r2._numerator);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(_numerator), Math.Abs(_denorminator));
    }

    public RationalNumber Reduce()
    {
        return this;
    }

    public RationalNumber Exprational(int power)
    {
        return new RationalNumber((int)Math.Pow(_numerator, Math.Abs(power)), (int)Math.Pow(_denorminator, Math.Abs(power)));
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}