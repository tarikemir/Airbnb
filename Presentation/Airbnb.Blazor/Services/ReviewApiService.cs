using Airbnb.Blazor.Interfaces;
using Airbnb.Domain.Entities;
using MySqlX.XDevAPI.Common;

namespace Airbnb.Blazor.Services
{
    public class ReviewApiService : IReviewApiService
    {
        private readonly HttpClient _httpClient;

        public ReviewApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Review>> GetReviews()
        {
            return await _httpClient.GetFromJsonAsync<List<Review>>("api/reviews");
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Review>($"api/reviews/{id}");
        }

        public async Task<int> GetReviewsCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("api/reviews/count");
        }

        public async Task<Review> CreateReview(Review review)
        {
            return await _httpClient.PostAsJsonAsync<Review>("api/reviews", review).Result.Content.ReadFromJsonAsync<Review>();
        }

        public async Task UpdateReview(Review review)
        {
            await _httpClient.PutAsJsonAsync($"api/reviews/{review.id}", review);
        }

        public async Task DeleteReview(int id)
        {
            await _httpClient.DeleteAsync($"api/reviews/{id}");
        }
    }


}
