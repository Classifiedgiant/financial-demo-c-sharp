using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FinancialDemo.Util;

namespace FinancialDemoTesting
{
    class SimpleRateInput
    {
        public double presentValue;
        public double rate;
    }

    class ComplexRateInput
    {
        public double presentValue;
        public double rate;
        public float period;
    }

    [TestClass]
    public class SimpleRateTests
    {
        [TestMethod]
        public void returns_correct_values()
        {
            const double threshold = 0.0000010;

            SimpleRateInput[] input = new SimpleRateInput[] 
            {
                new SimpleRateInput{presentValue = 100, rate = 0.5},
                new SimpleRateInput{presentValue = 11, rate = 0.36},
                new SimpleRateInput{presentValue = 5689, rate = 0.2},
                new SimpleRateInput{presentValue = 552.0, rate = 0.8},
                new SimpleRateInput{presentValue = 20.56, rate = 0.3333}
            };

            double expected = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                double presentValue = input[i].presentValue;
                double rate = input[i].rate;

                expected = presentValue * (1 + rate);
                Assert.AreEqual(expected, FixedIncomeCalculator.CalculateSimpleRate(presentValue, rate), threshold);
            }
        }
    }

    [TestClass]
    public class CompoundInterestTests
    {
        ComplexRateInput[] input;

        [TestInitialize]
        public void set_up()
        {
            input = new ComplexRateInput[] 
        {
            new ComplexRateInput{presentValue = 100, rate = 0.5, period = 3f},
            new ComplexRateInput{presentValue = 11, rate = 0.36, period = 45f},
            new ComplexRateInput{presentValue = 5689, rate = 0.2, period = 12f},
            new ComplexRateInput{presentValue = 552.0, rate = 0.8, period = 0.5f},
            new ComplexRateInput{presentValue = 20.56, rate = 0.3333, period = 36f}
        };
        }

        [TestCleanup]
        public void tear_down()
        {
            input = null;
        }
           
        [TestMethod]
        public void discrete_rate_return_correct_values()
        {
            const double threshold = 0.0000010;

            double expected = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                double presentValue = input[i].presentValue;
                double rate = input[i].rate;
                float period = input[i].period;

                expected = presentValue * Math.Pow(1 + rate, period);
                Assert.AreEqual(expected, FixedIncomeCalculator.CalculateDiscreteRate(presentValue, rate, period), threshold);
            }
        }

        [TestMethod]
        public void continous_rate_return_correct_values()
        {
            const double threshold = 0.0000010;

            double expected = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                double presentValue = input[i].presentValue;
                double rate = input[i].rate;
                float period = input[i].period;

                expected = presentValue * Math.Exp(rate * period);
                Assert.AreEqual(expected, FixedIncomeCalculator.CalculateContinousRate(presentValue, rate, period), threshold);
            }
        }
    }
}
