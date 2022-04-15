using BethanysPieShopHRM.Shared;
using System.Text.Json;

namespace BethanysPieShopHRM.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient httpClient;

        public JobCategoryDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(
                await httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await JsonSerializer.DeserializeAsync<JobCategory>(
               await httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
