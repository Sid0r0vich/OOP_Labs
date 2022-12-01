using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Task1;

public class Phase3Test
{
    [Test]
    public void TestOperators()
    {
        var r1 = new Rational(1, 2);
        var r2 = new Rational(1, 3);
        var r3 = new Rational(1, 4);
        Multiple(() =>
        {
            //Fail("Раскомментируйте тесты ниже и реализуйте требуемую функциональность в классе Rational");
            /* Читайте про перегрузку операторов на https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading */
            /* пример сигнатуры функции public static Rational operator +(Rational r1, Rational r2)*/
            
            That(r1 + r2, Is.EqualTo(new Rational(5, 6)));
            That(r1 - r2, Is.EqualTo(new Rational(1, 6)));
            That(r1 * r2, Is.EqualTo(new Rational(1, 6)));
            That(r1 / r2, Is.EqualTo(new Rational(3, 2)));

            That(r3 + (Rational)1, Is.EqualTo(new Rational(5, 4)));
            That(r3 - (Rational)1, Is.EqualTo(new Rational(-3, 4)));

            That(r1.CompareTo(r2) > 0, Is.True);
            That(r1 > r2, Is.True);
            That(r1 >= r2, Is.True);
            That(r1 < r2, Is.False);
            That(r1 <= r2, Is.False);
            That(r1 != -r1, Is.True);
        });
    }

    [Test]
    public void TestToMixedVulgarFractions()
    {
        Rational r1 = new(1, 7);
        Rational r2 = new(5, 4);
        Rational r3 = new(31, 4);

        Console.WriteLine(VulgarFractions.ToMixedVulgarFraction(r2));
        That(VulgarFractions.ToMixedVulgarFraction(r1), Is.EqualTo("¹/₇"));
        That(VulgarFractions.ToMixedVulgarFraction(r2), Is.EqualTo("1¹/₄"));
        That(VulgarFractions.ToMixedVulgarFraction(r3), Is.EqualTo("7³/₄"));
    }
}