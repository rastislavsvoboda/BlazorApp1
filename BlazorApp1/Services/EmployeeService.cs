using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp1.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            //https://nitinrestapi.azurewebsites.net/api/employees
            return await httpClient.GetJsonAsync<Employee[]>("api/employees");
        }
    }
}
