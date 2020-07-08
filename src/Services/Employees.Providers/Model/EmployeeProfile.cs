using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Employees.Providers.Model
{
    public class EmployeeProfile
    {
        [DataMember (Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "contractTypeName")]
        public string ContractTypeName { get; set; }

        [DataMember(Name = "roleId")]
        public int RoleId { get; set; }

        [DataMember(Name = "roleName")]
        public string RoleName { get; set; }

        [DataMember(Name = "roleDescription")]
        public string RoleDescription { get; set; }

        [DataMember(Name = "hourlySalary")]
        public decimal HourlySalary { get; set; }

        [DataMember(Name = "monthlySalary")]
        public decimal MonthlySalary { get; set; }
    }
}
