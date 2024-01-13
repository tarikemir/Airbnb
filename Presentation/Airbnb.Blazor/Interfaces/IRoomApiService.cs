using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Interfaces
{
    public interface IRoomApiService
    {
        Task<List<Room>> GetRooms();
        Task<int> GetRoomsCount();
        Task<Room> GetRoom(int roomId);
        Task CreateRoom(Room room);
        Task UpdateRoom(int roomId, Room room);
        Task DeleteRoom(int roomId);
    }

}
