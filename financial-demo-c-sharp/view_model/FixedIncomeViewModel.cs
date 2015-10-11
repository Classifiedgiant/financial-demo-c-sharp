using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinancialDemo.Model;


namespace FinancialDemo.ViewModel
{
    class FixedIncomeViewModel : BaseViewModel
    {
        FixedIncomeModel m_model;

        public FixedIncomeViewModel()
        {
            m_model = new FixedIncomeModel();
        }

        public string Value
        {
            get { return m_model.Value.ToString();}
            set { m_model.Value = Double.Parse(value); OnPropertyChanged(null); }
        }

        public string InterestRate
        {
            get {return m_model.InterestRate.ToString();}
            set { m_model.InterestRate = Double.Parse(value); OnPropertyChanged(null); }

        }

        public string Period
        {
            get {return m_model.Period.ToString();}
            set { m_model.Period = Int32.Parse(value); OnPropertyChanged(null); }
        }

        public string SimpleRate
        {
            get { return m_model.SimpleRate.ToString(); }
        }

        public string DiscreteRate
        {
            get { return m_model.DiscreteRate.ToString(); }
        }

        public string ContinousRate
        {
            get { return m_model.ContinousRate.ToString(); }
        }
    }
}
