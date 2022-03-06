namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : Controller
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;

    public ReviewsController(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
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
}