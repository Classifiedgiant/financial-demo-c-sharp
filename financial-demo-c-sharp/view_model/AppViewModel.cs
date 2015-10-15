using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinancialDemo.Model;

namespace FinancialDemo.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        private AppModel m_appModel;
        //private FixedIncomeViewModel m_fixedIncomeViewModel;
        private ChartViewModel m_chartViewModel;

        private double  m_interestRate;
        private double  m_presentValue;
        private float   m_period;

        private double m_simpleRate;
        private double m_discreteRate;
        private double m_continousRate;

        public AppViewModel()
        {
            m_appModel = new AppModel();
            m_chartViewModel = new ChartViewModel(m_appModel.FixedIncomeModel);
            
            m_interestRate = 8.0f;
            m_presentValue = 5000.0;
            m_period = 5;

            CalculateAll();
        }

        public ChartViewModel ChartVM
        {
            get { return m_chartViewModel; }
            set { m_chartViewModel = value; OnPropertyChanged("ChartVM"); }
        }

        public string PresentValue
        {
            get { return m_presentValue.ToString(); }
            set 
            { 
                m_presentValue = Double.Parse(value);
                CalculateAll();
                OnPropertyChanged(null); 
            }
        }

        public string InterestRate
        {
            get { return m_interestRate.ToString(); }
            set 
            { 
                m_interestRate = Double.Parse(value);
                CalculateAll(); 
                OnPropertyChanged(null); 
            }
        }

        public string Period
        {
            get { return m_period.ToString(); }
            set 
            { 
                m_period = float.Parse(value);
                CalculateAll(); 
                OnPropertyChanged(null); 
            }
        }


        public string SimpleRate
        {
            get { return m_simpleRate.ToString("c2"); }
            //set { m_simpleRate = value.ToString(); }

        }

        public string DiscreteRate
        {
            get { return m_discreteRate.ToString("c2"); }
            //set { m_discreteRate = value.ToString(); }

        }

        public string ContinousRate
        {
            get { return m_continousRate.ToString("c2"); }
        }

        private void CalculateAll()
        {
            double rate = m_interestRate / 100.0;
            m_simpleRate = m_appModel.FixedIncomeModel.CalculateSimpleInterest(m_presentValue, rate);
            m_discreteRate = m_appModel.FixedIncomeModel.CalculateDiscreteCompoundInterest(m_presentValue, rate, m_period);
            m_continousRate = m_appModel.FixedIncomeModel.CalculateContinousCompoundInterest(m_presentValue, rate, m_period);
            ChartVM.CreateGraphNode(m_presentValue, rate, m_period, 1);
        }
    }
}
