using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()

        {
            Employees = new List<Employee>();

            Employees = (await EmployeeService.GetEmployees()).ToList();

        }
        protected async Task DeleteEmployee(int employeeId)
        {
            var confirm = await JSRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to delete this employee?");
            if (confirm)
            {
                await EmployeeService.DeleteEmployee(employeeId);
                // Remove the employee from the Employees list
                Employees = Employees.Where(e => e.EmployeeId != employeeId).ToList();

                // Trigger a re-render of the component
                StateHasChanged();
            }
        }


    }
}

