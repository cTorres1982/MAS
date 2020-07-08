using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Core.DTOs;
using Employees.Core.Entities;
using Employees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            var employees = await _employeeService.GetEmployees();
            var dtos = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return dtos;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeDTO> Get(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }
    }
}
