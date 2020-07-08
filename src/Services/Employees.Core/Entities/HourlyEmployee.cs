using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Core.Entities
{
    public class HourlyEmployee : Employee
    {
        public override decimal AnnualSalary {
            get {
                return 120 * HourlySalary * 12;
            }
            set { 
            
            }
        }
    }
}
