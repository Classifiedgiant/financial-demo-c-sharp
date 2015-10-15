using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using FinancialDemo.Model;
using FinancialDemo.Util;

namespace FinancialDemo.ViewModel
{
    public class ChartViewModel : BaseViewModel
    {
        private ObservableCollection<Point> m_discreteDataPoints;
        private ObservableCollection<Point> m_continuousDataPoints;

        private FixedIncomeModel m_fixedIncomeModel;
        
        public ChartViewModel(FixedIncomeModel fixedIncomeModel)
        {
            m_discreteDataPoints = new ObservableCollection<Point>();
            m_continuousDataPoints = new ObservableCollection<Point>();
            m_fixedIncomeModel = fixedIncomeModel;
        }

        public void CreateGraphNode(double presentValue, double interestRate, float period, float interval)
        {
            m_discreteDataPoints.Clear();
            m_continuousDataPoints.Clear();
            for (float i = 0; i <= period; i+=interval)
            {
                double discreteRate = FixedIncomeCalculator.CalculateDiscreteRate(presentValue, interestRate, i);
                double continousRate = FixedIncomeCalculator.CalculateContinousRate(presentValue, interestRate, i);
                discreteRate = Math.Round(discreteRate, 2);
                continousRate = Math.Round(continousRate, 2);
                m_discreteDataPoints.Add(new Point(i, discreteRate));
                m_continuousDataPoints.Add(new Point(i, continousRate));
            }
        }

        public ObservableCollection<Point> DiscreteLine
        {
            get { return m_discreteDataPoints; }
            set { m_discreteDataPoints = value; OnPropertyChanged("DiscreteLine"); }
        }

        public ObservableCollection<Point> ContinousLine
        {
            get { return m_continuousDataPoints; }
            set { m_continuousDataPoints = value; OnPropertyChanged("ContinousLine"); }
        }

        public string XAxis { get { return "Period"; } }
        public string YAxis { get { return "Price (GBP)"; } }
    }
}
