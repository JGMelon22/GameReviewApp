namespace GameReviewApp.Interfaces;

public interface IGameRepository
{
    ICollection<Game> GetGames();
    Game GetGame(int id);
    Game GetGame(string name);
    decimal GetGameRating(int gameId);
    bool GameExists(int id);

    // Signatures
    bool CreateGame(int publisherId, int categoryId, Game game);
    bool UpdateGame(int publisherId, int categoryId, Game game);
    bool DeleteGame(Game gameId);
    bool Save();
}