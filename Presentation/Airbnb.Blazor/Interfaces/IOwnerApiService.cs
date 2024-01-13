using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Interfaces
{
    public interface IOwnerApiService
    {
        Task<List<Owner>> GetOwners();
        Task<Owner> GetOwnerById(int id);
        Task<int> GetOwnersCount();
        Task<Owner> CreateOwner(Owner owner);
        Task UpdateOwner(int id, Owner owner);
        Task DeleteOwner(int id);
    }

}
