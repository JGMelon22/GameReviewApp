using System.ComponentModel.DataAnnotations.Schema;

namespace GameReviewApp.Models;

public class Category
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;
    
    // Many to many
    public ICollection<GameCategory> GameCategories { get; set; }
}