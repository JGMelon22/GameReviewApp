namespace GameReviewApp.Interfaces;

public interface IPublisherRepository
{
    ICollection<Publisher> GetPublishers();
    Publisher GetPublisher(int id);
    ICollection<Publisher> GetPublisherOfAGame(int gameId);
    ICollection<Game> GetGameByPublisher(int publisherId);
    bool PublisherExists(int id);
}