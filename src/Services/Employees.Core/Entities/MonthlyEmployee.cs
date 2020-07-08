using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Core.Entities
{
    public class MonthlyEmployee : Employee
    {
        public override decimal AnnualSalay
        {
            get
            {
                return MonthlySalary * 12;
            }
            set
            {

            }
        }
    }
}
