using Airbnb.Blazor.Interfaces;
using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Services
{
    public class RenterApiService : IRenterApiService
    {
        private readonly HttpClient _httpClient;

        public RenterApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Renter>> GetRenters()
        {
            return await _httpClient.GetFromJsonAsync<List<Renter>>("/api/renters");
        }

        public async Task<Renter> GetRenterById(int renterId)
        {
            return await _httpClient.GetFromJsonAsync<Renter>($"/api/renters/{renterId}");
        }

        public async Task<int> GetRentersCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("/api/renters/count");
        }

        public async Task CreateRenter(Renter renter)
        {
            await _httpClient.PostAsJsonAsync("/api/renters", renter);
        }

        public async Task UpdateRenter(int renterId, Renter renter)
        {
            await _httpClient.PutAsJsonAsync($"/api/renters/{renterId}", renter);
        }

        public async Task DeleteRenter(int renterId)
        {
            await _httpClient.DeleteAsync($"/api/renters/{renterId}");
        }
    }

}
