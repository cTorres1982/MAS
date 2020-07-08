using BackendProxy.Config;
using BackendProxy.DTOs;
using BackendProxy.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendProxy
{
    public class EmployeesProxy : IEmployeesProxy
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmployeesProxy> _logger;
        private readonly BackendConfig _backendConfig;

        public EmployeesProxy(HttpClient httpClient, ILogger<EmployeesProxy> logger, IOptions<BackendConfig> options)
        {
            _httpClient = httpClient;
            _logger = logger;
            _backendConfig = options.Value;
        }

        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var request = await _httpClient.GetAsync($"{_backendConfig.Url}/employees/{id}");
            request.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<EmployeeDTO>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var request = await _httpClient.GetAsync($"{_backendConfig.Url}/employees");
            request.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<IEnumerable<EmployeeDTO>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
