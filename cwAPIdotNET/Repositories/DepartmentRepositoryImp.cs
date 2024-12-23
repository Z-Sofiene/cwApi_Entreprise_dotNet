using Magasin.Config;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Repositories;

namespace cwAPIdotNET.Repositories
{
    public class DepartmentRepositoryImp : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        // Department CRUD operations
        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return await _context.Set<Department>().FindAsync(departmentId);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Set<Department>().ToListAsync();
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Set<Department>().Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _context.Set<Department>().Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int departmentId)
        {
            var department = await GetDepartmentByIdAsync(departmentId);
            if (department == null) return false;

            _context.Set<Department>().Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

        // Other department-specific operations
        public async Task<bool> DepartmentExistsAsync(int departmentId)
        {
            return await _context.Set<Department>().AnyAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<int> GetDepartmentEmployeeCountAsync(int departmentId)
        {
            return await _context.Set<Employee>().CountAsync(e => e.DepartmentId == departmentId);
        }
    }
}
