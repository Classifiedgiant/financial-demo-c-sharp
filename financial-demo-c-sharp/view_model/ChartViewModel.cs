using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using FinancialDemo.Util;

namespace FinancialDemo.ViewModel
{
    public class ChartViewModel : BaseViewModel
    {
        private ObservableCollection<Point> discreteDataPoints;
        private ObservableCollection<Point> continuousDataPoints;

        public ChartViewModel()
        {
            discreteDataPoints = new ObservableCollection<Point>();
            continuousDataPoints = new ObservableCollection<Point>();
        }

        public void CreateGraphNode(double presentValue, double interestRate, float period, float interval)
        {
            discreteDataPoints.Clear();
            continuousDataPoints.Clear();
            for (float i = 0; i <= period; i+=interval)
            {
                double discreteRate = FixedIncomeCalculator.CalculateDiscreteRate(presentValue, interestRate, i);
                double continousRate = FixedIncomeCalculator.CalculateContinousRate(presentValue, interestRate, i);
                discreteRate = Math.Round(discreteRate, 2);
                continousRate = Math.Round(continousRate, 2);
                discreteDataPoints.Add(new Point(i, discreteRate));
                continuousDataPoints.Add(new Point(i, continousRate));
            }
        }

        public ObservableCollection<Point> DiscreteLine
        {
            get { return discreteDataPoints; }
            set { discreteDataPoints = value; OnPropertyChanged("DiscreteLine"); }
        }

        public ObservableCollection<Point> ContinousLine
        {
            get { return continuousDataPoints; }
            set { continuousDataPoints = value; OnPropertyChanged("ContinousLine"); }
        }

        public string XAxis { get { return "Period"; } }
        public string YAxis { get { return "Price (GBP)"; } }
    }
}
