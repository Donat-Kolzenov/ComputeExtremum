using System;

namespace OneVariableEquation.ComputeExtremumMethod
{
    public class GoldenSection : IComputableExtremum
    {
        private static readonly double PHI = (1 + Math.Sqrt(5)) / 2;

        /// <inheritdoc cref="IComputableExtremum.FindMin"/>
        /// <param name="Equation"> Заданная функция. </param>
        /// <param name="a"> Начало отрезка. </param>
        /// <param name="b"> Конец отрезка. </param>
        /// <param name="eps"> Точность. </param>
        public double FindMin(
            Func<double, double> Equation,
            double a,
            double b,
            double eps)
        {
            while (Math.Abs(b - a) > eps)
            {
                double x1 = b - (b - a) / PHI;
                double x2 = a + (b - a) / PHI;

                if (Equation(x1) >= Equation(x2))
                    a = x1;
                else
                    b = x2;
            }
            return (a + b) / 2;
        }

        /// <inheritdoc cref="IComputableExtremum.FindMax"/>
        /// <param name="Equation"> Заданная функция. </param>
        /// <param name="a"> Начало отрезка. </param>
        /// <param name="b"> Конец отрезка. </param>
        /// <param name="eps"> Точность. </param>
        public double FindMax(
            Func<double, double> Equation,
            double a,
            double b,
            double eps)
        {
            while (Math.Abs(b - a) > eps)
            {
                double x1 = b - (b - a) / PHI;
                double x2 = a + (b - a) / PHI;

                if (Equation(x1) <= Equation(x2))
                    a = x1;
                else
                    b = x2;
            }
            return (a + b) / 2;
        }
    }
}