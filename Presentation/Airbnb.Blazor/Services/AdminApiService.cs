using Airbnb.BlazorApp.Interfaces;
using Airbnb.Domain.Entities;

namespace Airbnb.BlazorApp.Services
{
    public class AdminApiService : IAdminApiService
    {
        private readonly HttpClient _httpClient;

        public AdminApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Admin>> GetAdmins()
        {
            return await _httpClient.GetFromJsonAsync<List<Admin>>("api/Admins");
        }

        public async Task<Admin> GetAdminById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Admin>($"api/Admins/{id}");
        }

        public async Task<int> GetAdminsCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("api/Admins/count");
        }

        public async Task<Admin> CreateAdmin(Admin admin)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Admins", admin);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Admin>();
        }

        public async Task UpdateAdmin(int id, Admin admin)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Admins/{id}", admin);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAdmin(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Admins/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}
