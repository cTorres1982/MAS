using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace BackendProxy.DTOs
{
    public class EmployeeDTO
    {
        private string _name;
        private string _contractTypeName;
        private string _roleName;
        private string _roleDescription;

        public int Id { get; set; }
        public string Name { get { return _name??string.Empty; } set { _name = value; } }
        [Display (Name = "Contract Type")]
        public string ContractTypeName { 
            get { 
                if (string.IsNullOrEmpty(_contractTypeName))
                {
                    return string.Empty;
                }
                switch (_contractTypeName.ToLower())
                {
                    case "monthlysalaryemployee":
                        return "Monthly";
                    case "hourlysalaryemployee":
                        return "Hourly";
                    default:
                        return string.Empty;
                }
            } 
            set { _contractTypeName = value; } 
        }
        public int RoleId { get; set; }
        [Display(Name = "Role")]
        public string RoleName { get { return _roleName ?? string.Empty; } set { _roleName = value; } }
        public string RoleDescription { get { return _roleDescription ?? string.Empty; } set { _roleDescription = value; } }
        [DataType(DataType.Currency)]
        public decimal HourlySalary { get; set; }
        [DataType(DataType.Currency)]
        public decimal MonthlySalary { get; set; }
        [Display(Name = "Annual Salary")]
        [DataType(DataType.Currency)]
        public decimal AnnualSalary { get; set; }
    }
}
