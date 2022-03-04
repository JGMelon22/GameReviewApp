namespace GameReviewApp.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty!;

    // Many to many
    public ICollection<GameCategory> GameCategories { get; set; }
}