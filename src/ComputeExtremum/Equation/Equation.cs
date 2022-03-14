namespace ComputeExtremum.Equation
{
    using System;
    using ComputeExtremum.Method;

    public class Equation
    {
        private Func<double, double> _function;

        private IComputableExtremum _extremumMethod;

        private static readonly string s_functionErrorMessage;

        private static readonly string s_extremumErrorMessage;

        static Equation()
        {
            s_functionErrorMessage =
                "Equation function was not found!";

            s_extremumErrorMessage =
                "Method to compute extremum was not found!";
        }

        public Equation(Func<double, double> function) =>
            Function = function;

        public Equation(
            Func<double, double> function,
            IComputableExtremum extremumMethod) : this(function) =>
                ExtremumMethod = extremumMethod;

        /// <exception cref="System.NullReferenceException"> </exception>
        public Func<double, double> Function
        {
            get => this._function;

            set => this._function = value ??
                throw new NullReferenceException(s_functionErrorMessage);
        }

        /// <exception cref="System.NullReferenceException"> </exception>
        public IComputableExtremum ExtremumMethod
        {
            private get => this._extremumMethod;

            set => this._extremumMethod = value ??
                throw new NullReferenceException(s_extremumErrorMessage);
        }

        /// <inheritdoc cref="IComputableExtremum.FindMin"/>
        /// <param name="a"> Начало отрезка. </param>
        /// <param name="b"> Конец отрезка. </param>
        /// <param name="eps"> Точность. </param>
        /// <exception cref="System.NullReferenceException">
        /// бросается в случае, если пытаемся найти
        /// минимимум функции методом <paramref name="ExtremumMethod"/>,
        /// который равен null.
        /// </exception>
        public double FindMin(double a, double b, double eps)
        {
            return ExtremumMethod?.FindMin(Function, a, b, eps) ??
                throw new NullReferenceException(s_extremumErrorMessage);
        }

        /// <inheritdoc cref="IComputableExtremum.FindMax"/>
        /// <param name="a"> Начало отрезка. </param>
        /// <param name="b"> Конец отрезка. </param>
        /// <param name="eps"> Точность. </param>
        /// <exception cref="System.NullReferenceException">
        /// бросается в случае, если пытаемся найти
        /// максимум функции методом <paramref name="ExtremumMethod"/>,
        /// который равен null.
        /// </exception>
        public double FindMax(double a, double b, double eps)
        {
            return ExtremumMethod?.FindMax(Function, a, b, eps) ??
                throw new NullReferenceException(s_extremumErrorMessage);
        }
    }
}