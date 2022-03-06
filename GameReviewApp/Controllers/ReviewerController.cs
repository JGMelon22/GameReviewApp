namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewerController : Controller
{
    private readonly IMapper _mapper;
    private readonly IReviewerRepository _reviewerRepository;

    public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
    {
        _reviewerRepository = reviewerRepository;
        _mapper = mapper;
    }

    // GET 
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
    public IActionResult GetReviewers()
    {
        var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(reviewers);
    }

    // GET by Id
    [HttpGet("{reviewerId}")]
    [ProducesResponseType(200, Type = typeof(Game))]
    [ProducesResponseType(400)]
    public IActionResult GetGame(int reviewerId)
    {
        if (!_reviewerRepository.ReviewExists(reviewerId)) return BadRequest("Invalid settings");

        var reviewer = _mapper.Map<ReviewDto>(_reviewerRepository.GetReviewer(reviewerId));

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(reviewer);
    }

    // GET reviews from a reviewer
    [HttpGet("{reviewerId}/reviews")]
    public IActionResult GetReviewsByAReviewer(int reviewerId)
    {
        if (!_reviewerRepository.ReviewExists(reviewerId))
            return NotFound("The requested reviewerId do not exists");

        var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewByReviewer(reviewerId));

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(reviews);
    }
}