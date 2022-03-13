namespace GameReviewApp.Interfaces;

public interface IReviewerRepository
{
    ICollection<Reviewer> GetReviewers();
    Reviewer GetReviewer(int id);
    ICollection<Review> GetReviewByReviewer(int reviewerId);
    bool ReviewerExists(int id);

    // Signatures
    bool CreateReviewers(Reviewer reviewer);
    bool UpdateReviewers(Reviewer reviewer);
    bool Save();
}