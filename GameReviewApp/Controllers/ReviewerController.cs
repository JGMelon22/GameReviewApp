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
        if (!_reviewerRepository.ReviewerExists(reviewerId)) return BadRequest("Invalid settings");

        var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(reviewer);
    }

    // GET reviews from a reviewer
    [HttpGet("{reviewerId}/reviews")]
    public IActionResult GetReviewsByAReviewer(int reviewerId)
    {
        if (!_reviewerRepository.ReviewerExists(reviewerId))
            return NotFound("The requested reviewerId do not exists");

        var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewByReviewer(reviewerId));

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(reviews);
    }

    // POST
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateReviewer([FromBody] ReviewerDto reviewerCreate)
    {
        if (reviewerCreate == null) return BadRequest(ModelState);

        var reviewer = _reviewerRepository.GetReviewers()
            .Where(x => x.LastName.Trim().ToUpper() == reviewerCreate.LastName.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (reviewer != null)
        {
            ModelState.AddModelError("", "Reviewer already registered");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var reviewerMap = _mapper.Map<Reviewer>(reviewerCreate);

        if (!_reviewerRepository.CreateReviewers(reviewerMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }

    // PUT
    [HttpPut("{reviewerId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateReviewer(int reviewerId, [FromBody] ReviewerDto updatedReviewer)
    {
        if (updatedReviewer == null)
            return BadRequest(ModelState);

        if (reviewerId != updatedReviewer.Id)
            return BadRequest(ModelState);

        if (!_reviewerRepository.ReviewerExists(reviewerId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var reviewerMap = _mapper.Map<Reviewer>(updatedReviewer);

        if (!_reviewerRepository.UpdateReviewers(reviewerMap))
        {
            ModelState.AddModelError("", "Something went wrong while updating the reviewer");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }
}