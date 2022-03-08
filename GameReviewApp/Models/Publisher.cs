namespace GameReviewApp.Models;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }

    // One publisher is related to one country 
    // It's main HQ
    public Country Country { get; set; }

    // Many to many
    public ICollection<GamePublisher> GamePublishers { get; set; }
}