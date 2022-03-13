namespace GameReviewApp.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Game> GetGameByCategory(int categoryId);
    bool CategoryExists(int id);

    // Signatures
    bool CreateCategory(Category category);
    bool UpdateCategory(Category category);
    bool Save();
}