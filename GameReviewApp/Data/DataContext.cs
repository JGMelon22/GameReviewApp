using GameReviewApp.Models;

namespace GameReviewApp.Data;

public class DataContext : DbContext
{
    private readonly DataContext _context;

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    // Points to the tables we want to create 
    // Using EF Core
    public DbSet<Category> Categories { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameCategory> GamesCategories { get; set; }
    public DbSet<GamePublisher> GamesPublishers { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }

    // Setting up relationship using EF Core
    // Based on the join tables
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        # region PK and many to many

        // GameCategory --> GameId with CategoryId
        modelBuilder.Entity<GameCategory>()
            .HasKey(x => new {x.GameId, x.CategoryId});
        modelBuilder.Entity<GameCategory>()
            .HasOne(x => x.Game)
            .WithMany(y => y.GameCategories)
            .HasForeignKey(z => z.GameId);
        modelBuilder.Entity<GameCategory>()
            .HasOne(x => x.Category)
            .WithMany(y => y.GameCategories)
            .HasForeignKey(z => z.GameId);

        // GamePublisher --> GameId with PublisherId
        modelBuilder.Entity<GamePublisher>()
            .HasKey(x => new {x.GameId, x.PublisherId});
        modelBuilder.Entity<GamePublisher>()
            .HasOne(x => x.Game)
            .WithMany(y => y.GamePublishers)
            .HasForeignKey(z => z.GameId);
        modelBuilder.Entity<GamePublisher>()
            .HasOne(x => x.Publisher)
            .WithMany(y => y.GamePublishers)
            .HasForeignKey(z => z.PublisherId);

        # endregion
    }
}