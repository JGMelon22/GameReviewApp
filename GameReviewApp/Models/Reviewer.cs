namespace GameReviewApp.Models;

public class Reviewer
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty!;
    public string LastName { get; set; } = string.Empty!;

    public ICollection<Review> Reviews { get; set; }
}