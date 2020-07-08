using Employees.Core.Entities;
using Employees.Core.Interfaces;
using Employees.Providers.Config;
using Employees.Providers.Converters;
using Employees.Providers.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employees.Providers.Repositories
{
    public class EmployeeProxy : IEmployeeProxy
    {
        private readonly HttpClient _httpClient;
        private readonly ApiConfig _apiConfig;
        private readonly ILogger _logger;
        public EmployeeProxy(HttpClient httpClient, IOptions<ApiConfig> apiConfig, ILogger<EmployeeProxy> logger)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig.Value;
            _logger = logger;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var request = await _httpClient.GetAsync($"{_apiConfig.Url}employees");
            request.EnsureSuccessStatusCode();
            IEnumerable<EmployeeProfile> profiles = JsonSerializer.Deserialize<IEnumerable<EmployeeProfile>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );

            List<Employee> output = new List<Employee>();

            foreach(EmployeeProfile profile in profiles)
            {
                try
                {
                    output.Add(Converter.GetEmployee(profile));
                }
                catch(Exception ex)
                {
                    _logger.LogWarning(ex, "Conversion failure");
                }
            }

            return output;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            IEnumerable<Employee> employees = await GetEmployees();

            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
