namespace GameReviewApp.Models;

public class Review
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty!;
    public string Text { get; set; } = string.Empty!;
    public int Rating { get; set; }

    public Reviewer Reviewer { get; set; }
    public Game Game { get; set; }
}