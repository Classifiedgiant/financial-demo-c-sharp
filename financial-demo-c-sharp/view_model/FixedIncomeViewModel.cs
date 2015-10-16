using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinancialDemo.Model;
using FinancialDemo.Util;

namespace FinancialDemo.ViewModel
{
    public class FixedIncomeViewModel : BaseViewModel
    {
        private ChartViewModel m_chartViewModel;
        private FixedIncomeModel m_fixedIncomeModel;

        public FixedIncomeViewModel()
        {
            m_chartViewModel = new ChartViewModel();
            m_fixedIncomeModel = new FixedIncomeModel();
            m_chartViewModel.CreateGraphNode(m_fixedIncomeModel.PresentValue, m_fixedIncomeModel.InterestRate / 100.0f, m_fixedIncomeModel.Period, 1);
        }

        public ChartViewModel ChartVM
        {
            get { return m_chartViewModel; }
            set { m_chartViewModel = value; OnPropertyChanged("ChartVM"); }
        }

        public string PresentValue
        {
            get { return m_fixedIncomeModel.PresentValue.ToString(); }
            set
            {
                m_fixedIncomeModel.PresentValue = Double.Parse(value);
                m_chartViewModel.CreateGraphNode(m_fixedIncomeModel.PresentValue, m_fixedIncomeModel.InterestRate / 100.0f, m_fixedIncomeModel.Period, 1);
                OnPropertyChanged(null);
            }
        }

        public string InterestRate
        {
            get { return m_fixedIncomeModel.InterestRate.ToString(); }
            set
            {
                m_fixedIncomeModel.InterestRate = Double.Parse(value);
                m_chartViewModel.CreateGraphNode(m_fixedIncomeModel.PresentValue, m_fixedIncomeModel.InterestRate / 100.0f, m_fixedIncomeModel.Period, 1);
                OnPropertyChanged(null);
            }
        }

        public string Period
        {
            get { return m_fixedIncomeModel.Period.ToString(); }
            set
            {
                m_fixedIncomeModel.Period = float.Parse(value);
                m_chartViewModel.CreateGraphNode(m_fixedIncomeModel.PresentValue, m_fixedIncomeModel.InterestRate / 100.0f, m_fixedIncomeModel.Period, 1);
                OnPropertyChanged(null);
            }
        }

        public string SimpleRate
        {
            get { return m_fixedIncomeModel.SimpleRate.ToString("c2"); }
        }

        public string DiscreteRate
        {
            get { return m_fixedIncomeModel.DiscreteRate.ToString("c2"); }
        }

        public string ContinousRate
        {
            get { return m_fixedIncomeModel.ContinousRate.ToString("c2"); }
        }
    }
}
