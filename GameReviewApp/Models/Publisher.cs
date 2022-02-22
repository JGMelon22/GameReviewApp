namespace GameReviewApp.Models;

public class Publisher
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty!;

    // One publisher is related to one country 
    // It's main HQ
    public Country Country { get; set; }

    // Many to many
    public ICollection<GamePublisher> GamePublishers { get; set; }
}