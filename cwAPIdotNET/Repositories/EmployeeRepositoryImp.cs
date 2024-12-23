using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;
using Magasin.Config;

public class EmployeeRepositoryImp : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepositoryImp(AppDbContext context)
    {
        _context = context;
    }

    // Employee CRUD operations
    public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
    {
        return await _context.Set<Employee>().FindAsync(employeeId);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Set<Employee>().ToListAsync();
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        _context.Set<Employee>().Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        _context.Set<Employee>().Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> DeleteEmployeeAsync(int employeeId)
    {
        var employee = await GetEmployeeByIdAsync(employeeId);
        if (employee == null) return false;

        _context.Set<Employee>().Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }

    // Additional employee-specific operations
    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
    {
        return await _context.Set<Employee>().Where(e => e.DepartmentId == departmentId).ToListAsync();
    }

    public async Task<Employee> GetEmployeeByEmailAsync(string email)
    {
        return await _context.Set<Employee>().FirstOrDefaultAsync(e => e.Email == email);
    }

    public async Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchTerm)
    {
        return await _context.Set<Employee>()
            .Where(e => e.FirstName.Contains(searchTerm) || e.LastName.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task<int> GetEmployeeCountAsync()
    {
        return await _context.Set<Employee>().CountAsync();
    }

    public async Task<bool> EmployeeExistsAsync(int employeeId)
    {
        return await _context.Set<Employee>().AnyAsync(e => e.EmployeeId == employeeId);
    }

   
}
