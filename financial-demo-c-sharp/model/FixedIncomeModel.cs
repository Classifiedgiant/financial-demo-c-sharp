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
        private double m_interestRate;
        private double m_presentValue;
        private float m_period;

        private double m_simpleRate;
        private double m_discreteRate;
        private double m_continousRate;

        public FixedIncomeModel()
        {
            m_interestRate = 8.0f;
            m_presentValue = 5000.0;
            m_period = 5;
        }

        private void CalculateAll()
        {
            double rate = m_interestRate / 100.0;
            m_simpleRate = FixedIncomeCalculator.CalculateSimpleRate(m_presentValue, rate);
            m_discreteRate = FixedIncomeCalculator.CalculateDiscreteRate(m_presentValue, rate, m_period);
            m_continousRate = FixedIncomeCalculator.CalculateContinousRate(m_presentValue, rate, m_period);
        }

        public double PresentValue
        {
            get { return m_presentValue; }
            set
            {
                m_presentValue = value;
                CalculateAll();
            }
        }

        public double InterestRate
        {
            get { return m_interestRate; }
            set
            {
                m_interestRate = value;
                CalculateAll();
            }
        }

        public float Period
        {
            get { return m_period; }
            set
            {
                m_period = value;
                CalculateAll();
            }
        }

        public double SimpleRate
        {
            get { return m_simpleRate; }
        }

        public double DiscreteRate
        {
            get { return m_discreteRate; }
        }

        public double ContinousRate
        {
            get { return m_continousRate; }
        }
    }
}
