using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FinancialDemo.Model;

namespace FinancialDemoTesting
{
    [TestClass]
    public class FixedIncomeModelTests
    {
        private FixedIncomeModel test;

        [TestInitialize]
        public void set_up()
        {
            test = new FixedIncomeModel();
        }

        [TestCleanup]
        public void tear_down()
        {
            test = null;
        }

        [TestMethod]
        public void constructions_set_properties_to_default()
        {
            Assert.AreEqual(8.0f, test.InterestRate);
            Assert.AreEqual(5000.0, test.PresentValue);
            Assert.AreEqual(5, test.Period);
        }

        [TestMethod]
        public void can_set_properties()
        {
            test.InterestRate = 110;
            test.PresentValue = 456;
            test.Period = 156;
            Assert.AreEqual(110, test.InterestRate);
            Assert.AreEqual(456, test.PresentValue);
            Assert.AreEqual(156, test.Period);
        }

        [TestMethod]
        public void updating_a_property_recalculates_rates()
        {
            double simpleRate = test.SimpleRate;
            double discreteRate = test.DiscreteRate;
            double continousRate = test.ContinousRate;

            test.Period = 1;
            Assert.AreNotEqual(simpleRate, test.SimpleRate);
            Assert.AreNotEqual(discreteRate, test.DiscreteRate);
            Assert.AreNotEqual(continousRate, test.ContinousRate);

        }
    }
}
