using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EmployeeApiController : ControllerBase
{
    private readonly IEmployeeRepository EmpDAO;

    public EmployeeApiController(IEmployeeRepository employeeRepository)
    {
        EmpDAO = employeeRepository;
    }

    // GET: api/Employee
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
    {
        var employees = await EmpDAO.GetAllEmployeesAsync();
        return Ok(employees);
    }

    // GET: api/Employee/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        var employee = await EmpDAO.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    // POST: api/Employee
    [HttpPost]
    public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
    {
        var createdEmployee = await EmpDAO.AddEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.EmployeeId }, createdEmployee);
    }

    // PUT: api/Employee/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeId)
        {
            return BadRequest("Employee ID mismatch.");
        }

        var result = await EmpDAO.UpdateEmployeeAsync(employee);
        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Employee/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var success = await EmpDAO.DeleteEmployeeAsync(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    // Additional endpoint examples for employees
    [HttpGet("department/{departmentId}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDepartment(int departmentId)
    {
        var employees = await EmpDAO.GetEmployeesByDepartmentIdAsync(departmentId);
        return Ok(employees);
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> GetEmployeeCount()
    {
        var count = await EmpDAO.GetEmployeeCountAsync();
        return Ok(count);
    }
}
