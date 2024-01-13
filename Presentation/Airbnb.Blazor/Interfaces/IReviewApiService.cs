using Airbnb.Domain.Entities;

namespace Airbnb.Blazor.Interfaces
{
    public interface IReviewApiService
    {
        Task<List<Review>> GetReviews();
        Task<Review> GetReviewById(int id);
        Task<int> GetReviewsCount();
        Task<Review> CreateReview(Review review);
        Task UpdateReview(Review review);
        Task DeleteReview(int id);
    }


}
