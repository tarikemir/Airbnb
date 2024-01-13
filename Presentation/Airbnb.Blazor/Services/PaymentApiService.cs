using Airbnb.Blazor.Interfaces;
using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Services
{
    public class PaymentApiService : IPaymentApiService
    {
        private readonly HttpClient httpClient;

        public PaymentApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Payment>> GetPayments()
        {
            return await httpClient.GetFromJsonAsync<List<Payment>>("api/payments");
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            return await httpClient.GetFromJsonAsync<Payment>($"api/payments/{paymentId}");
        }

        public async Task<int> GetPaymentsCount()
        {
            return await httpClient.GetFromJsonAsync<int>("api/payments/count");
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            return await httpClient.PostAsJsonAsync("api/payments", payment).Result.Content.ReadFromJsonAsync<Payment>();
        }

        public async Task UpdatePayment(int paymentId, Payment payment)
        {
            await httpClient.PutAsJsonAsync($"api/payments/{paymentId}", payment);
        }

        public async Task DeletePayment(int paymentId)
        {
            await httpClient.DeleteAsync($"api/payments/{paymentId}");
        }
    }

}
