namespace GameReviewApp.Repository;

public class PublisherRepository : IPublisherRepository
{
    private readonly DataContext _context;

    public PublisherRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Publisher> GetPublishers()
    {
        return _context.Publishers.OrderBy(x => x.Id).ToList();
    }

    public Publisher GetPublisher(int id)
    {
        return _context.Publishers.Where(x => x.Id == id).FirstOrDefault();
    }

    public ICollection<Publisher> GetPublisherOfAGame(int gameId)
    {
        return _context.GamesPublishers
            .Where(x => x.Game.Id == gameId)
            .Select(y => y.Publisher) // Again a Select due to EF Join tables
            .ToList();
    }

    public ICollection<Game> GetGameByPublisher(int publisherId)
    {
        return _context.GamesPublishers
            .Where(x => x.Publisher.Id == publisherId)
            .Select(y => y.Game)
            .ToList();
    }

    public bool PublisherExists(int publisherId)
    {
        return _context.Publishers.Any(x => x.Id == publisherId);
    }
}