using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Interfaces
{
    public interface IPaymentApiService
    {
        Task<List<Payment>> GetPayments();
        Task<Payment> GetPaymentById(int paymentId);
        Task<int> GetPaymentsCount();
        Task<Payment> CreatePayment(Payment payment);
        Task UpdatePayment(int paymentId, Payment payment);
        Task DeletePayment(int paymentId);
    }

}
