namespace GameReviewApp.Repository;

public class ReviewerRepository : IReviewerRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewerRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<Reviewer> GetReviewers()
    {
        return _context.Reviewers
            .OrderBy(x => x.Id)
            .ToList();
    }

    public Reviewer GetReviewer(int id)
    {
        return _context.Reviewers
            .Where(x => x.Id == id)
            .Include(y => y.Reviews) // or .Select(x)
            .FirstOrDefault();
    }

    public ICollection<Review> GetReviewByReviewer(int reviewerId)
    {
        return _context.Reviews
            .Where(x => x.Reviewer.Id == reviewerId)
            .ToList();
    }

    public bool ReviewExists(int reviewerId)
    {
        return _context.Reviewers.Any(x => x.Id == reviewerId);
    }
}