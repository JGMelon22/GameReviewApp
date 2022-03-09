namespace GameReviewApp.Interfaces;

public interface IReviewerRepository
{
    ICollection<Reviewer> GetReviewers();
    Reviewer GetReviewer(int id);
    ICollection<Review> GetReviewByReviewer(int reviewerId);
    bool ReviewExists(int id);
    
    // Signatures
    bool CreateReviewers(Reviewer reviewer);
    bool Save();
}