
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class AddEmployeeBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee
        {
            EmployeeId = 0,
            DateOfBirth = new DateTime(1990, 5, 9),
            DepartmentId = 1
           // PhotoPath = ""
        };

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        protected async Task HandleFormSubmit()
        {

            Employee.EmployeeId = 0;
            await EmployeeService.AddEmployee(Employee);
            NavigateToEmployeeList();
        }

        protected async Task HandleFileChange(InputFileChangeEventArgs e)
        {
            Employee.PhotoPath = "";
            var file = e.File;
            if (file != null)
            {
                // Define the file path in the wwwroot/images directory
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, file.Name);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                }

                // Set the relative path for the photo (to be stored in the Employee's model)
                Employee.PhotoPath = $"images/{file.Name}";
            }
        }
        protected void NavigateToEmployeeList()
        {
            NavigationManager.NavigateTo("/EmployeeList");
        }
    }
}
