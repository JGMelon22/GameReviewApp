namespace GameReviewApp.Models;

public class GamePublisher
{
    public int GameId { get; set; }
    public int PublisherId { get; set; }

    public Game GameCategory { get; set; }
    public Publisher Publisher { get; set; }
}