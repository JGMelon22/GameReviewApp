using System.ComponentModel.DataAnnotations.Schema;

namespace GameReviewApp.Models;

public class Game
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty!;
    public DateTime ReleaseDate { get; set; }

    // One game will have many reviews from different users
    public ICollection<Review> Reviews { get; set; }
    public ICollection<GamePublisher> GamePublishers { get; set; }
    public ICollection<GameCategory> GameCategories { get; set; }
}