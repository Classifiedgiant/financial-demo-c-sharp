using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDemo.Model
{
    public class AppModel
    {
        private FixedIncomeModel m_fixedIncomeModel;

        public AppModel()
        {
            m_fixedIncomeModel = new FixedIncomeModel();
        }

        public FixedIncomeModel FixedIncomeModel
        {
            get { return m_fixedIncomeModel; }
            set { m_fixedIncomeModel = value; }
        }
    }
}
