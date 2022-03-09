namespace GameReviewApp.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<Review> GetReviews()
    {
        return _context.Reviews.OrderBy(x => x.Id).ToList();
    }

    public Review GetReview(int id)
    {
        return _context.Reviews
            .Where(x => x.Id == id)
            .FirstOrDefault();
    }

    public ICollection<Review> GetReviewsOfAGame(int gameId)
    {
        return _context.Reviews
            .Where(x => x.Game.Id == gameId)
            .ToList();
    }

    public bool ReviewExists(int id)
    {
        return _context.Reviews.Any(x => x.Id == id);
    }

    public bool CreateReview(Review review)
    {
        _context.Add(review);
        return Save();

    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}