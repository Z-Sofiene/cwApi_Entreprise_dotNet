using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace cwAP
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository DepDAO;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            DepDAO = departmentRepository;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var departments = await DepDAO.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        // GET: api/Department/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var department = await DepDAO.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            var createdDepartment = await DepDAO.AddDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = createdDepartment.DepartmentId }, createdDepartment);
        }

        // PUT: api/Department/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest("Department ID mismatch.");
            }

            var result = await DepDAO.UpdateDepartmentAsync(department);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(department );
        }

        // DELETE: api/Department/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var success = await DepDAO.DeleteDepartmentAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Additional endpoint examples for departments
        [HttpGet("{id}/employeeCount")]
        public async Task<ActionResult<int>> GetDepartmentEmployeeCount(int id)
        {
            var count = await DepDAO.GetDepartmentEmployeeCountAsync(id);
            return Ok(count);
        }
    }
}
