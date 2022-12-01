using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Task1;

public class Rational : IComparable<Rational>
{
    public readonly int numerator;
    public readonly int denominator;
    
    public bool IsZero { get => this.numerator == 0; }
    public bool IsWhole { get => this.numerator % this.denominator == 0; }
    public int WholePart { get => this.numerator / this.denominator; }
    public int ProperPart { get => this.numerator % this.denominator; }

    public Rational(int numerator, int denominator)
    {
        (this.numerator, this.denominator) = Init(numerator, denominator);
    }

    public Rational(int wholePart, int Numerator, int Denominator) 
        : this(wholePart * Denominator + Numerator * (wholePart >= 0 ? 1 : -1), Denominator) { }

    public Rational(string StrPart)
    {
        string[] Parts = StrPart.Split('/');
        (this.numerator, this.denominator) = Init(int.Parse(Parts[0]), int.Parse(Parts[1]));
    }

    public (int, int) Init(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("Denominator can not be 0!");

        int nod = Math.Abs(Task1.main.NOD(numerator, denominator));
        if (denominator < 0)
            nod *= -1;

        numerator /= nod;
        denominator /= nod;

        return (numerator, denominator);
    }

    public override bool Equals(object obj)
    {
        Rational rational = (Rational)obj;

        if (rational.numerator == this.numerator &&
            rational.denominator == this.denominator)
            return true;

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.numerator, this.denominator);
    }

    public override string ToString()
    {
        if (denominator != 1)
            return $"{numerator}/{denominator}";

        return $"{numerator}";
    }

    public static Rational operator +(Rational rational) => rational;

    public static Rational operator -(Rational rational) =>
        new Rational(-rational.numerator, rational.denominator);

    public static Rational operator +(Rational rational1, Rational rational2) =>
        new Rational(rational1.numerator * rational2.denominator +
                     rational2.numerator * rational1.denominator,
                     rational1.denominator * rational2.denominator);

    public static Rational operator -(Rational rational1, Rational rational2) =>
        new Rational(rational1.numerator * rational2.denominator -
                     rational2.numerator * rational1.denominator,
                     rational1.denominator * rational2.denominator);

    public static Rational operator *(Rational rational1, Rational rational2) =>
        new Rational(rational1.numerator * rational2.numerator,
                     rational1.denominator * rational2.denominator);

    public static Rational operator /(Rational rational1, Rational rational2) =>
    new Rational(rational1.numerator * rational2.denominator,
                 rational1.denominator * rational2.numerator);

    public int CompareTo(Rational other)
    {
        return (this.numerator * other.denominator).CompareTo(other.numerator * this.numerator);
    }

    public static bool operator <(Rational rational1, Rational rational2) 
    { 
        return rational1.CompareTo(rational2) < 0;
    }

    public static bool operator <=(Rational rational1, Rational rational2)
    {
        return rational1.CompareTo(rational2) <= 0;
    }

    public static bool operator >(Rational rational1, Rational rational2)
    {
        return rational1.CompareTo(rational2) > 0;
    }

    public static bool operator >=(Rational rational1, Rational rational2)
    {
        return rational1.CompareTo(rational2) >= 0;
    }

    public static implicit operator Rational(int i) => new(i, 1);
}