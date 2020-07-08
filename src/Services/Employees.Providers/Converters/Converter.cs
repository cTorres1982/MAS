using Employees.Core.Entities;
using Employees.Providers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Providers.Converters
{
    public static class Converter
    {
        public static Employee GetEmployee(EmployeeProfile input)
        {
            if (input == null) { throw new Exception("Null employee profile"); }

            if (string.IsNullOrEmpty(input.ContractTypeName)) { throw new Exception("Contract type isn't defined"); }

            Employee output;

            switch (input.ContractTypeName.ToLower())
            {
                case "hourlysalaryemployee":
                    output = new HourlyEmployee();
                    break;
                case "monthlysalaryemployee":
                    output = new MonthlyEmployee();
                    break;
                default:
                    throw new Exception("Invalid contract type");
            }

            output.ContractTypeName = input.ContractTypeName;
            output.HourlySalary = input.HourlySalary;
            output.MonthlySalary = input.MonthlySalary;
            output.Name = input.Name;
            output.RoleDescription = input.RoleDescription;
            output.RoleId = input.RoleId;
            output.RoleName = input.RoleName;
            output.Id = input.Id;

            return output;
        }
    }
}
