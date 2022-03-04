namespace GameReviewApp.Repository;

public class GameRepository : IGameRepository
{
    private readonly DataContext _context;

    public GameRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Game> GetGames()
    {
        return _context.Games.OrderBy(x => x.Id).ToList();
    }

    public Game GetGame(int id)
    {
        return _context.Games.Where(x => x.Id == id).FirstOrDefault();
    }

    public Game GetGame(string name)
    {
        return _context.Games.Where(x => x.Name == name).FirstOrDefault();
    }

    public decimal GetGameRating(int gameId)
    {
        var review = _context.Reviews.Where(x => x.Game.Id == gameId);
        if (review.Count() <= 0) return 0; // No reviews were created yet

        // Rating avg
        return (decimal) review.Sum(x => x.Rating) / review.Count();
    }

    public bool GameExists(int gameId)
    {
        return _context.Games.Any(x => x.Id == gameId);
    }
}