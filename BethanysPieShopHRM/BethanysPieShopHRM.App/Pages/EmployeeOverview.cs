using BethanysPieShopHRM.App.Components;
using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
		public IEnumerable<Employee>? Employees { get; set; }

		[Inject]
		public IEmployeeDataService? EmployeeDataService { get; set; }

		protected AddEmployeeDialog? AddEmployeeDialog { get; set; }

        protected async override Task OnInitializedAsync()
        {
			if(EmployeeDataService != null)
				Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
		}

		protected void QuickAddEmployee()
        {
			AddEmployeeDialog.Show();
        }

		public async Task AddEmployeeDialog_OnDialogClose()
        {
			Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
			StateHasChanged();
        }
	}
}
