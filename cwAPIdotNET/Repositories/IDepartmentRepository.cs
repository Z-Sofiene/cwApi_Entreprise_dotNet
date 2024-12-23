using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IDepartmentRepository
    {

        // Department CRUD operations (if managed within this service)
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(int departmentId);

        // Other department-specific operations
        Task<bool> DepartmentExistsAsync(int departmentId);
        Task<int> GetDepartmentEmployeeCountAsync(int departmentId);
    }
}
