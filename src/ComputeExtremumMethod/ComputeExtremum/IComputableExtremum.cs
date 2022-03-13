namespace ComputeExtremum
{
    using System;

    public interface IComputableExtremum
    {
        /// <summary>
        /// Метод поиска минимума функции на заданном отрезке.
        /// </summary> 
        /// <param name="Equation"> Заданная функция. </param>
        /// <param name="a"> Начало отрезка. </param>
        /// <param name="b"> Конец отрезка. </param>
        /// <param name="eps"> Точность. </param>
        /// <returns> Минимум функции на заданном отрезке. </returns>
        double FindMin(
            Func<double, double> Equation,
            double a,
            double b,
            double eps);

        /// <summary>
        /// Метод поиска максимума функции на заданном отрезке.
        /// </summary>
        /// <param name="Equation"> Заданная функция. </param>
        /// <param name="a"> Начало отрезка. </param>
        /// <param name="b"> Конец отрезка. </param>
        /// <param name="eps"> Точность. </param>
        /// <returns> Максимум функции на заданном отрезке. </returns>
        double FindMax(
            Func<double, double> Equation,
            double a,
            double b,
            double eps);
    }
}