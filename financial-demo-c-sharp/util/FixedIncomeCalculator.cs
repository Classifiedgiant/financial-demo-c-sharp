using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDemo.Util
{
    public class FixedIncomeCalculator
    {
        static public double CalculateSimpleRate(double presentValue, double rate)
        {
            return presentValue * (1 + rate);
        }

        static public double CalculateDiscreteRate(double presentValue, double rate, float period)
        {
            return presentValue * Math.Pow(1 + rate, period);
        }

        static public double CalculateContinousRate(double presentValue, double rate, float period)
        {
            return presentValue * Math.Exp(rate * period);
        }
    }
}
