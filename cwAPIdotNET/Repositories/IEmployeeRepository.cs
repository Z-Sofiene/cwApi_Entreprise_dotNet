using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

public interface IEmployeeRepository
{
    // Employee CRUD operations
    Task<Employee> GetEmployeeByIdAsync(int employeeId);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Employee employee);
    Task<bool> DeleteEmployeeAsync(int employeeId);

    // Additional employee-specific operations
    Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId);
    Task<Employee> GetEmployeeByEmailAsync(string email);
    Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchTerm);
    Task<int> GetEmployeeCountAsync();
    Task<bool> EmployeeExistsAsync(int employeeId);

}
