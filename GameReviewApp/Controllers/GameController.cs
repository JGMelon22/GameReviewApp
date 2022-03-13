namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : Controller
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;
    private readonly IReviewerRepository _reviewerRepository;

    public GameController(IGameRepository gameRepository,
        IReviewerRepository reviewerRepository,
        IMapper mapper) // Mr Fancy pants AutoMapper DI
    {
        _gameRepository = gameRepository;
        _reviewerRepository = reviewerRepository;
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
    public IActionResult GetGame(int gameId)
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

    // POST
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateGame([FromQuery] int publisherId, [FromQuery] int catId,
        [FromBody] GameDto gameCreate)
    {
        if (gameCreate == null) return BadRequest(ModelState);

        var games = _gameRepository.GetGames()
            .Where(x => x.Name.Trim().ToUpper() == gameCreate.Name.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (games != null)
        {
            ModelState.AddModelError("", "The publisher already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var gameMap = _mapper.Map<Game>(gameCreate);

        if (!_gameRepository.CreateGame(publisherId, catId, gameMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }

    // PUT  
    [HttpPut("{gameId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateGame(int gameId,
        [FromQuery] int publisherId, [FromQuery] int catId,
        [FromBody] GameDto updatedGame)
    {
        if (updatedGame == null)
            return BadRequest(ModelState);

        if (gameId != updatedGame.Id)
            return BadRequest(ModelState);

        if (!_gameRepository.GameExists(gameId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var gameMap = _mapper.Map<Game>(updatedGame);

        if (!_gameRepository.UpdateGame(publisherId, catId, gameMap))
        {
            ModelState.AddModelError("", "Something went wrong while updating the game");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }
}