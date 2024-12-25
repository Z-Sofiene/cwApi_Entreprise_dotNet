using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Models;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Employee.EmployeeId != 0)
            {
                await EmployeeService.UpdateEmployee(Employee);
            }

            NavigateToEmployeeList();
        }

        protected void NavigateToEmployeeList()
        {
            NavigationManager.NavigateTo("/EmployeeList");
        }
    }
}
