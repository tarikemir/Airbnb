using Airbnb.Blazor.Interfaces;
using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Services
{
    public class ReservationApiService : IReservationApiService
    {
        private readonly HttpClient _httpClient;

        public ReservationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            return await _httpClient.GetFromJsonAsync<List<Reservation>>("api/reservations");
        }

        public async Task<Reservation> GetReservationById(int reservationId)
        {
            return await _httpClient.GetFromJsonAsync<Reservation>($"api/reservations/{reservationId}");
        }

        public async Task<int> GetReservationsCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("api/reservations/count");
        }

        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            return await _httpClient.PostAsJsonAsync<Reservation>("api/reservations", reservation).Result.Content.ReadFromJsonAsync<Reservation>();
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            await _httpClient.PutAsJsonAsync($"api/reservations/{reservation.reservation_id}", reservation);
        }

        public async Task DeleteReservation(int reservationId)
        {
            await _httpClient.DeleteAsync($"api/reservations/{reservationId}");
        }
    }

}
