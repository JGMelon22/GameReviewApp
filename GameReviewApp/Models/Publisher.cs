namespace GameReviewApp.Models;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;

    // One publisher is related to one country 
    // It's main HQ
    public Country Country { get; set; }
}