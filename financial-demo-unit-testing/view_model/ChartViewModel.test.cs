using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FinancialDemo.ViewModel;

namespace FinancialDemoTesting
{
    [TestClass]
    public class ChartViewModelTests
    {
        private ChartViewModel test;

        [TestInitialize]
        public void set_up()
        {
            test = new ChartViewModel();
        }

        [TestCleanup]
        public void tear_down()
        {
            test = null;
        } 
        [TestMethod]
        public void constructions_set_properties_to_default()
        {
            Assert.AreEqual(0, test.DiscreteLine.Count);
            Assert.AreEqual(0, test.ContinousLine.Count);
            Assert.AreEqual("Period", test.XAxis);
            Assert.AreEqual("Price (GBP)", test.YAxis);
        }


        [TestMethod]
        public void CalculateGraphNode_can_run_with_no_periods()
        {
            test.CreateGraphNode(10, 0.5, 0, 1);
            Assert.AreEqual(1, test.DiscreteLine.Count);
            Assert.AreEqual(1, test.ContinousLine.Count);
        }

        [TestMethod]
        public void CalculateGraphNode_generates_correct_points()
        {
            float period = 10;
            float interval = 5;
            test.CreateGraphNode(10, 0.5, period, interval);
            Assert.AreEqual(period/interval + 1, test.DiscreteLine.Count);
            Assert.AreEqual(period/interval + 1, test.ContinousLine.Count);

        }    
    }
}
