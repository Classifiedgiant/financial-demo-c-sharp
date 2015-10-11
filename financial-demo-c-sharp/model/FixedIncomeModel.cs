using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDemo.Model
{
    class FixedIncomeModel
    {
        private double m_presentValue;
        private double m_interestRate; 
        private int m_period;
        private double m_simpleRate;
        private double m_discreteCompoundRate;
        private double m_continousCompoundRate;

        public FixedIncomeModel()
        {
            m_presentValue = 5000.0f;
            m_interestRate = 8.0;
            m_period = 5;
        }

        public void CalculateAll()
        {
            CalculateSimpleInterest();
            CalculateDiscreteCompoundInterest();
            CalculateContinousCompoundInterest();
        }

        public double Value
        {
            get { return m_presentValue; }
            set { m_presentValue = value; CalculateAll(); }
        }

        public double InterestRate
        {
            get { return m_interestRate; }
            set { m_interestRate = value; CalculateAll(); }
        }

        public int Period
        {
            get { return m_period; }
            set { m_period = value; CalculateAll(); }
        }

        public double SimpleRate
        {
            get { return m_simpleRate; }
        }

        public double DiscreteRate
        {
            get { return m_discreteCompoundRate; }
        }

        public double ContinousRate
        {
            get { return m_continousCompoundRate; }
        }

        private void CalculateSimpleInterest()
        {
            double rate = m_interestRate / 100.0f;
            m_simpleRate = m_presentValue * (1 + rate);
        }

        private void CalculateDiscreteCompoundInterest()
        {
            double rate = m_interestRate / 100.0f;
            m_discreteCompoundRate = m_presentValue * Math.Pow((1 + rate), m_period);
        }

        private void CalculateContinousCompoundInterest()
        {
            double rate = m_interestRate / 100.0f;
            m_continousCompoundRate = m_presentValue * Math.Exp(rate * m_period);
        }
    }
}
