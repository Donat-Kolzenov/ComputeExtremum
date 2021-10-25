using System;
using OneVariableEquation.ComputeExtremumMethod;

namespace OneVariableEquation
{
    public class Equation
    {
        private Func<double, double> _viewForm;
        private IComputableExtremum _computeExtremumMethod;

        private static string s_extremumErrorMessage;
        private static string s_viewFormErrorMessage;

        static Equation()
        {
            Equation.s_extremumErrorMessage =
                "Method to compute extremum was not found!";

            Equation.s_viewFormErrorMessage =
                "Form of equation view was not found!";
        }

        public Equation(Func<double, double> ViewForm) =>
            this.ViewForm = ViewForm;

        public Equation(
            Func<double, double> ViewForm,
            IComputableExtremum ComputeExtremumMethod) : this(ViewForm) =>
                this.ComputeExtremumMethod = ComputeExtremumMethod;

        /// <exception cref="System.NullReferenceException"> </exception>
        public Func<double, double> ViewForm
        {
            get => this._viewForm;

            set => this._viewForm = value ??
                throw new NullReferenceException(s_viewFormErrorMessage);
        }

        /// <exception cref="System.NullReferenceException"> </exception>
        public IComputableExtremum ComputeExtremumMethod
        {
            private get => this._computeExtremumMethod;

            set => this._computeExtremumMethod = value ??
                throw new NullReferenceException(s_extremumErrorMessage);
        }

        /// <inheritdoc cref="IComputableExtremum.FindMin"/>
        /// <param name="a"> Начало отрезка. </param>
        /// <param name="b"> Конец отрезка. </param>
        /// <param name="eps"> Точность. </param>
        /// <exception cref="System.NullReferenceException">
        /// бросается в случае, если пытаемся найти
        /// минимимум функции методом <paramref name="ComputeExtremumMethod"/>,
        /// который равен null.
        /// </exception>
        public double FindMin(double a, double b, double eps)
        {
            return ComputeExtremumMethod?.FindMin(ViewForm, a, b, eps) ??
                throw new NullReferenceException(s_extremumErrorMessage);
        }

        /// <inheritdoc cref="IComputableExtremum.FindMax"/>
        /// <param name="a"> Начало отрезка. </param>
        /// <param name="b"> Конец отрезка. </param>
        /// <param name="eps"> Точность. </param>
        /// <exception cref="System.NullReferenceException">
        /// бросается в случае, если пытаемся найти
        /// максимум функции методом <paramref name="ComputeExtremumMethod"/>,
        /// который равен null.
        /// </exception>
        public double FindMax(double a, double b, double eps)
        {
            return ComputeExtremumMethod?.FindMax(ViewForm, a, b, eps) ??
                throw new NullReferenceException(s_extremumErrorMessage);
        }
    }
}