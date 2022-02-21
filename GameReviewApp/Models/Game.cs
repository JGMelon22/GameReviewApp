namespace GameReviewApp.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty!;
    public DateTime ReleaseDate { get; set; }

    // One game will have many reviews from different users
    public ICollection<Review> Reviews { get; set; }
}