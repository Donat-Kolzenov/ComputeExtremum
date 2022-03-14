namespace ComputeExtremum.Method.Dichotomy
{
    using System;

    public class Dichotomy : IComputableExtremum
    {
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
                double x = (a + b) / 2;

                if (Equation(x - eps) >= Equation(x + eps))
                    a = x;
                else
                    b = x;
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
                double x = (a + b) / 2;

                if (Equation(x - eps) < Equation(x + eps))
                    a = x;
                else
                    b = x;
            }
            return (a + b) / 2;
        }
    }
}