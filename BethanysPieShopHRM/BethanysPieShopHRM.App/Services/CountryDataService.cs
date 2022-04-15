using BethanysPieShopHRM.Shared;
using System.Text.Json;

namespace BethanysPieShopHRM.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(
                await httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Country> GetCountryById(int countryId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await JsonSerializer.DeserializeAsync<Country>(
                await httpClient.GetStreamAsync($"api/country/{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
