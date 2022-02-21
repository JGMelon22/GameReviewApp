using System.ComponentModel.DataAnnotations.Schema;

namespace GameReviewApp.Models;

public class Review
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;
    public string Text { get; set; } = String.Empty!;

    public Reviewer Reviewers { get; set; }
    public Game Game { get; set; }
    
}