using Airbnb.Blazor.Interfaces;
using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Services
{
    public class OwnerApiService : IOwnerApiService
    {
        private readonly HttpClient _httpClient;

        public OwnerApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Owner>> GetOwners()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Owner>>("api/owners");
            return response;
        }

        public async Task<Owner> GetOwnerById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Owner>($"api/owners/{id}");
            return response;
        }

        public async Task<int> GetOwnersCount()
        {
            var response = await _httpClient.GetFromJsonAsync<int>("api/owners/count");
            return response;
        }

        public async Task<Owner> CreateOwner(Owner owner)
        {
            var response = await _httpClient.PostAsJsonAsync("api/owners", owner);
            return await response.Content.ReadFromJsonAsync<Owner>();
        }

        public async Task UpdateOwner(int id, Owner owner)
        {
            await _httpClient.PutAsJsonAsync($"api/owners/{id}", owner);
        }

        public async Task DeleteOwner(int id)
        {
            await _httpClient.DeleteAsync($"api/owners/{id}");
        }

    }
}
