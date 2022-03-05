namespace GameReviewApp.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
        return _context.Categories.Where(x => x.Id == id).FirstOrDefault();
    }

    public ICollection<Game> GetGameByCategory(int categoryId)
    {
        // We do a Select due to EF Core no automatically loads for us the navigation property
        return _context.GamesCategories
            .Where(x => x.CategoryId == categoryId)
            .Select(y => y.Game)
            .ToList();
    }

    public bool CategoryExists(int id)
    {
        return _context.Categories.Any(x => x.Id == id);
    }
}