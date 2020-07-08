using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendProxy;
using BackendProxy.DTOs;
using BackendProxy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MvcClient.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesProxy _proxy;
        private readonly ILogger _logger;
        public EmployeesController(IEmployeesProxy employeesProxy, ILogger<EmployeesController> logger)
        {
            _proxy = employeesProxy;
            _logger = logger;
        }
        [Route("[controller]/{id?}")]
        public async Task<IActionResult> Index(int? id)
        {
            try
            {
                if (id == null)
                {
                    var employees = await _proxy.GetEmployees();

                    return View(employees);
                }
                else
                {
                    List<EmployeeDTO> employees = new List<EmployeeDTO>();
                    
                    var employee = await _proxy.GetEmployee(id.Value);
                    employees.Add(employee);
                    return View(employees);
                }
                
            }catch(Exception Ex)
            {
                _logger.LogError(Ex,"Backend exception");
            }

            return View();
        }
    }
}
