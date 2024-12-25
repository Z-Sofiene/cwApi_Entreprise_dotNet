namespace EmployeeManagement.Web.Services
{
    using Models;
    using System.Net.Http;
    using System.Net.Http.Json;

    namespace EmployeeManagement.Web.Services
    {
        public class DepartementService : IDepartementService
        {
            private readonly HttpClient httpClient;

            public DepartementService(HttpClient httpClient)
            {
                this.httpClient = httpClient;
            }

            // Get all departments
            public async Task<IEnumerable<Department>> GetDepartments()
            {
                return await httpClient.GetFromJsonAsync<Department[]>("/api/Department");
            }

            // Get a department by id
            public async Task<Department> GetDepartment(int id)
            {
                return await httpClient.GetFromJsonAsync<Department>($"api/Department/{id}");
            }

            // Add a new department
            public async Task AddDepartment(Department department)
            {
                var response = await httpClient.PostAsJsonAsync("/api/Department", department);
                response.EnsureSuccessStatusCode();
            }

            // Update an existing department
            public async Task<Department> UpdateDepartment(Department department)
            {
                var response = await httpClient.PutAsJsonAsync($"api/Department/{department.DepartmentId}", department);
                return await response.Content.ReadFromJsonAsync<Department>();
            }

            // Delete a department
            public async Task DeleteDepartment(int departmentId)
            {
                var response = await httpClient.DeleteAsync($"api/Department/{departmentId}");
                response.EnsureSuccessStatusCode();
            }
        }
    }

}
