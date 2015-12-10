using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FinancialDemo.ViewModel;

namespace FinancialDemoTesting
{
    [TestClass]
    public class FixedIncomeViewModelTests
    {
        private FixedIncomeViewModel test;

        [TestInitialize]
        public void set_up()
        {
            test = new FixedIncomeViewModel();
        }

        [TestCleanup]
        public void tear_down()
        {
            test = null;
        }

        [TestMethod]
        public void constructs_correctly()
        {
            ChartViewModel expectedChartViewModel = new ChartViewModel();
            expectedChartViewModel.CreateGraphNode(5000.0, 0.08, 5.0f, 1.0f);
            Assert.AreEqual("£0.00", test.SimpleRate);
            Assert.AreEqual("£0.00", test.DiscreteRate);
            Assert.AreEqual("£0.00", test.ContinousRate);
            Assert.AreEqual("5000", test.PresentValue);
            Assert.AreEqual("8", test.InterestRate);
            Assert.AreEqual("5", test.Period);
        }
    }
}
