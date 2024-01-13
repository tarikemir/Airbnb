using Airbnb.Domain.Entities;

namespace Airbnb.BlazorApp.Interfaces
{
    public interface IAdminApiService
    {
        Task<List<Admin>> GetAdmins();
        Task<Admin> GetAdminById(int id);
        Task<int> GetAdminsCount();
        Task<Admin> CreateAdmin(Admin admin);
        Task UpdateAdmin(int id, Admin admin);
        Task DeleteAdmin(int id);

    }
}
