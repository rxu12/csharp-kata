using System;

public struct ComplexNumber
{
    private double _real;
    private double _imaginary;
    public ComplexNumber(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public double Real()
    {
        return _real;
    }

    public double Imaginary()
    {
        return _imaginary;
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        var mulReal = _real * other.Real() - _imaginary * other.Imaginary();
        var mulImg = _imaginary * other.Real() + _real * other.Imaginary();
        return new ComplexNumber(mulReal, mulImg);
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(_real + other.Real(), _imaginary + other.Imaginary());
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        return new ComplexNumber(_real - other.Real(), _imaginary - other.Imaginary());
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Abs()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Conjugate()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Exp()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}