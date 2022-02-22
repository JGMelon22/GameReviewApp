namespace GameReviewApp.Models;

public class Country
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty!;

    public ICollection<Publisher> Publishers { get; set; }
}