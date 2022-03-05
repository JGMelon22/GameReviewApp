using GameReviewApp.DTO;

namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : Controller
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GameController(IGameRepository gameRepository, IMapper mapper) // Mr Fancy pants AutoMapper DI
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    // (Using DTO)
    // GET
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
    public IActionResult GetGames()
    {
        var games = _mapper.Map<List<GameDto>>(_gameRepository.GetGames());

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(games);
    }

    // GET by Id
    [HttpGet("{gameId}")]
    [ProducesResponseType(200, Type = typeof(Game))] // Cleaner design
    [ProducesResponseType(400)]
    public IActionResult GetGames(int gameId)
    {
        if (!_gameRepository.GameExists(gameId)) return NotFound("The requested game does not exist!");

        var game = _mapper.Map<GameDto>(_gameRepository.GetGame(gameId));

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(game);
    }

    [HttpGet("{gameId}/rating")]
    [ProducesResponseType(200, Type = typeof(decimal))]
    [ProducesResponseType(400)]
    public IActionResult GetGamerating(int gameId)
    {
        if (!_gameRepository.GameExists(gameId)) return NotFound("The requested game does not exist!");

        var rating = _gameRepository.GetGameRating(gameId);

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(rating);
    }
}