using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Interfaces
{
    public interface IRenterApiService
    {
        Task<List<Renter>> GetRenters();
        Task<Renter> GetRenterById(int renterId);
        Task<int> GetRentersCount();
        Task CreateRenter(Renter renter);
        Task UpdateRenter(int renterId, Renter renter);
        Task DeleteRenter(int renterId);
    }

}
