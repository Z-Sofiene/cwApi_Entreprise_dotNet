using Models;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartementService
    {
       Task<IEnumerable<Department>> GetDepartments();
       Task<Department> GetDepartment(int id);
       Task AddDepartment(Department department);
       Task<Department> UpdateDepartment(Department department);
       Task DeleteDepartment(int departmentId);
    }
}
