using System.ComponentModel.DataAnnotations.Schema;

namespace GameReviewApp.Models;

public class Country
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;
    
    public ICollection<Publisher> Publishers { get; set; }
}