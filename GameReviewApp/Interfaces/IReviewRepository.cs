namespace GameReviewApp.Interfaces;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
    Review GetReview(int id);
    ICollection<Review> GetReviewsOfAGame(int gameId);
    bool ReviewExists(int id);

    // Signatures
    bool CreateReview(Review review);
    bool UpdateReview(Review review);
    bool DeleteReview(Review review);
    bool DeleteReviews(List<Review> reviews);
    bool Save();
}