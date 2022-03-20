namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : Controller
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;
    private readonly IReviewerRepository _reviewerRepository;
    private readonly IReviewRepository _reviewRepository;

    public ReviewsController(IMapper mapper, IReviewRepository reviewRepository, IReviewerRepository reviewerRepository,
        IGameRepository gameRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
        _reviewerRepository = reviewerRepository;
        _gameRepository = gameRepository;
    }

    // GET 
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
    public IActionResult GetReviews()
    {
        var games = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(games);
    }

    // GET by Id
    [HttpGet("{reviewId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
    [ProducesResponseType(400)]
    public IActionResult GetReview(int reviewId)
    {
        if (!_reviewRepository.ReviewExists(reviewId)) return NotFound("The requested review does not exist!");

        var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));
        {
            if (!ModelState.IsValid) return BadRequest("Invalid settings");

            return Ok(review);
        }
    }

    // Get review for a particular game
    [HttpGet("game/{gameId}")]
    [ProducesResponseType(200, Type = typeof(Review))]
    [ProducesResponseType(400)]
    public IActionResult GetReviewsForAGame(int gameId)
    {
        var review = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReview(gameId));

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(review);
    }

    // POST
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateReview([FromQuery] int reviewerId, [FromQuery] int gameId,
        [FromBody] ReviewDto reviewCreate)
    {
        if (reviewCreate == null) return BadRequest(ModelState);

        var reviews = _reviewRepository.GetReviews()
            .Where(x => x.Title.Trim().ToUpper() == reviewCreate.Title.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (reviews != null)
        {
            ModelState.AddModelError("", "Review already published");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var reviewMap = _mapper.Map<Review>(reviewCreate);

        reviewMap.Game = _gameRepository.GetGame(gameId);
        reviewMap.Reviewer = _reviewerRepository.GetReviewer(reviewerId);

        if (!_reviewRepository.CreateReview(reviewMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }

    // PUT
    [HttpPut("{reviewId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateReview(int reviewId, [FromBody] ReviewDto updatedReview)
    {
        if (updatedReview == null)
            return BadRequest(ModelState);

        if (reviewId != updatedReview.Id)
            return BadRequest(ModelState);

        if (!_reviewRepository.ReviewExists(reviewId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var reviewMap = _mapper.Map<Review>(updatedReview);

        if (!_reviewRepository.UpdateReview(reviewMap))
        {
            ModelState.AddModelError("", "Something went wrong while updating the review");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    // DELETE
    [HttpDelete("{reviewId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteReview(int reviewId)
    {
        if (!_reviewRepository.ReviewExists(reviewId))
            return NotFound();

        var reviewToDelete = _reviewRepository.GetReview(reviewId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_reviewRepository.DeleteReview(reviewToDelete))
            ModelState.AddModelError("", "Something went wrong while deleting review");

        return NoContent();
    }
}