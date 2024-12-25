
using Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace EmployeeManagement.Web.Services
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
            return await httpClient.GetFromJsonAsync<Employee[]>("/api/Employee");
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
        }
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var response = await httpClient.PutAsJsonAsync($"api/Employee/{employee.EmployeeId}", employee);
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task AddEmployee(Employee employee)
        {
            var emp = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                DepartmentId = employee.DepartmentId,
                PhotoPath = employee.PhotoPath
            };
            var response = await httpClient.PostAsJsonAsync("/api/Employee", emp);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var response = await httpClient.DeleteAsync($"api/employee/{employeeId}");
            response.EnsureSuccessStatusCode();
        }

    }
}