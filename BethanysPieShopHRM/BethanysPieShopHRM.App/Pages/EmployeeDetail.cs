﻿using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
		[Parameter]
		public string? EmployeeId { get; set; }

		public Employee Employee { get; set; } = new Employee();

		[Inject]
		public IEmployeeDataService? EmployeeDataService { get; set; }

		protected async override Task OnInitializedAsync()
		{
			if(EmployeeDataService != null)
				Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
		}
	}
}
