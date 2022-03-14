namespace ComputeExtremum.Tests
{
    using System;
    using NUnit.Framework;
    using ComputeExtremum.Equation;
    using ComputeExtremum.Method;
    using ComputeExtremum.Method.GoldenSection;
    using ComputeExtremum.Method.Dichotomy;

    [TestFixture(typeof(GoldenSection))]
    [TestFixture(typeof(Dichotomy))]
    public class ExtremumMethodUnitTest<MethodType>
        where MethodType : IComputableExtremum, new()
    {
        private const double EPS = 0.0001;

        private const double MIN_RESULT = -0.195;

        private const double MAX_RESULT = -5.139;

        private readonly MethodType _extremumMethod;

        private Equation _equation;

        public ExtremumMethodUnitTest()
        {
            _extremumMethod = new MethodType();
        }

        [SetUp]
        public void Setup()
        {
            static double func(double x) => Math.Pow(x + 1, 3) + 5 * Math.Pow(x, 2);
            _equation = new Equation(func, _extremumMethod);
        }

        [Test]
        public void FindMinTest()
        {
            const double BEGIN = -2;
            const double END = 2;
            var result = Math.Round(_equation.FindMin(BEGIN, END, EPS), 3);
            Assert.That(result == MIN_RESULT);
        }

        [Test]
        public void FindMaxTest()
        {
            const double BEGIN = -8;
            const double END = 0;
            var result = Math.Round(_equation.FindMax(BEGIN, END, EPS), 3);
            Assert.That(result == MAX_RESULT);
        }
    }
}