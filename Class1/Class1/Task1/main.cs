

using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Task1
{
    public class main
    {
        public static int NOD(int x, int y)
        {
            if (x * y == 0)
                return x + y;

            return NOD(y % x, x);
        }

        public static void MakeTable(int denominator)
        {
            int MaxRationalLen = Math.Pow(denominator, 2).ToString().Length * 2 + 3;
            string row = string.Empty.PadRight(denominator.ToString().Length + 2);

            for (int i = 1; i < denominator; i++)
            {
                row += new Rational(i, denominator).ToString().PadLeft(MaxRationalLen);
            }

            row += "\n";
            int RowLen = MaxRationalLen * denominator - 2;
            for (int i = 0; i < RowLen; i++)
                row += "-";
            row += "\n";

            for (int i = 1; i < denominator; i++)
            {
                row += new Rational(i, denominator).ToString().PadRight(MaxRationalLen);
                for (int j = 1; j < denominator; j++)
                {
                    row += (new Rational(i, denominator) * new Rational(j, denominator)).ToString().PadRight(MaxRationalLen);
                }

                row += "\n";
            }

            Console.WriteLine(row);
        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            MakeTable(10);
            VulgarFractions.GenerateTask();
        }
    }
}