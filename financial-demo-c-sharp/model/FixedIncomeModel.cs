using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinancialDemo.Util;

namespace FinancialDemo.Model
{
    public class FixedIncomeModel
    {
        private double interestRate;
        private double presentValue;
        private float period;

        private double simpleRate;
        private double discreteRate;
        private double continousRate;

        public FixedIncomeModel()
        {
            interestRate = 8.0f;
            presentValue = 5000.0;
            period = 5;
        }

        private void CalculateAll()
        {
            double rate = interestRate / 100.0;
            simpleRate = FixedIncomeCalculator.CalculateSimpleRate(presentValue, rate);
            discreteRate = FixedIncomeCalculator.CalculateDiscreteRate(presentValue, rate, period);
            continousRate = FixedIncomeCalculator.CalculateContinousRate(presentValue, rate, period);
        }

        public double PresentValue
        {
            get { return presentValue; }
            set
            {
                presentValue = value;
                CalculateAll();
            }
        }

        public double InterestRate
        {
            get { return interestRate; }
            set
            {
                interestRate = value;
                CalculateAll();
            }
        }

        public float Period
        {
            get { return period; }
            set
            {
                period = value;
                CalculateAll();
            }
        }

        public double SimpleRate
        {
            get { return simpleRate; }
        }

        public double DiscreteRate
        {
            get { return discreteRate; }
        }

        public double ContinousRate
        {
            get { return continousRate; }
        }
    }
}
