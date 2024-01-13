using Airbnb.Blazor.Interfaces;
using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Services
{
    public class RoomApiService : IRoomApiService
    {
        private readonly HttpClient httpClient;

        public RoomApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Room>> GetRooms()
        {
            return await httpClient.GetFromJsonAsync<List<Room>>("api/rooms");
        }

        public async Task<int> GetRoomsCount()
        {
            return await httpClient.GetFromJsonAsync<int>("api/rooms/count");
        }

        public async Task<Room> GetRoom(int roomId)
        {
            return await httpClient.GetFromJsonAsync<Room>($"api/rooms/{roomId}");
        }

        public async Task CreateRoom(Room room)
        {
            await httpClient.PostAsJsonAsync("api/rooms", room);
        }

        public async Task UpdateRoom(int roomId, Room room)
        {
            await httpClient.PutAsJsonAsync($"api/rooms/{roomId}", room);
        }

        public async Task DeleteRoom(int roomId)
        {
            await httpClient.DeleteAsync($"api/rooms/{roomId}");
        }
    }

}
