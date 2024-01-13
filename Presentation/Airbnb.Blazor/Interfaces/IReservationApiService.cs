using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Interfaces
{
    public interface IReservationApiService
    {
        Task<List<Reservation>> GetReservations();
        Task<Reservation> GetReservationById(int reservationId);
        Task<int> GetReservationsCount();
        Task<Reservation> CreateReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);
        Task DeleteReservation(int reservationId);
    }

}
