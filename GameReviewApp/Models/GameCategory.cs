namespace GameReviewApp.Models;

public class GameCategory
{
    public int GameId { get; set; }
    public int PublisherId { get; set; }

    public Game Games { get; set; }
    public Category Category { get; set; }
    
}