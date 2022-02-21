namespace GameReviewApp.Models;

public class Review
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;
    public string Text { get; set; } = String.Empty!;

    public Reviewer Reviewers { get; set; }
    public Game Game { get; set; }
    
}