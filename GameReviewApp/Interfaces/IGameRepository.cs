namespace GameReviewApp.Interfaces;

public interface IGameRepository
{
    ICollection<Game> GetGames();
}