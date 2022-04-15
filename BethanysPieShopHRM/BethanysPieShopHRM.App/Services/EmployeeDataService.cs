using BethanysPieShopHRM.Shared;
using System.Text.Json;

namespace BethanysPieShopHRM.App.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient httpClient;

        public EmployeeDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
#pragma warning disable CS8603 // Possible null reference return.

            try
            {
                var returnValue = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                    await httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await JsonSerializer.DeserializeAsync<Employee>(
                await httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
