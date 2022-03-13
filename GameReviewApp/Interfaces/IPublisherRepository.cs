namespace GameReviewApp.Interfaces;

public interface IPublisherRepository
{
    ICollection<Publisher> GetPublishers();
    Publisher GetPublisher(int id);
    ICollection<Publisher> GetPublisherOfAGame(int gameId);
    ICollection<Game> GetGameByPublisher(int publisherId);
    bool PublisherExists(int id);

    // Signatures
    bool CreatePublisher(Publisher publisher);
    bool UpdatePublisher(Publisher publisher);
    bool Save();
}