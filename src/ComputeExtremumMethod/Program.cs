namespace ExtremumDemonstration
{
    using System;
    using Equation;
    using ComputeExtremum.Method.GoldenSection;
    using ComputeExtremum.Method.Dichotomy;

    class Program
    {
        static void Main()
        {
            try
            {
                // range for find min
                double beginMin = -2;
                double endMin = 2;
                // range for find max
                double beginMax = -8;
                double endMax = 0;
                const double EPS = 0.001;

                var equation = new Equation(DemoEquation, new GoldenSection());
                Console.WriteLine("Extremum of demo equation by Golden Section method:");
                Console.WriteLine("Min: " + equation.FindMin(beginMin, endMin, EPS));
                Console.WriteLine("Max: " + equation.FindMax(beginMax, endMax, EPS));

                equation.ExtremumMethod = new Dichotomy();
                Console.WriteLine("Extremum of demo equation by Dichotomy method:");
                Console.WriteLine("Min: " + equation.FindMin(beginMin, endMin, EPS));
                Console.WriteLine("Max: " + equation.FindMax(beginMax, endMax, EPS));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static double DemoEquation(double x) => Math.Pow(x + 1, 3) + 5 * Math.Pow(x, 2);
    }
}
