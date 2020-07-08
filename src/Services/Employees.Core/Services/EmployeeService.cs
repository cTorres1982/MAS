using Employees.Core.Entities;
using Employees.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeProxy _employeeRepository;

        public EmployeeService(IEmployeeProxy employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }
    }
}
