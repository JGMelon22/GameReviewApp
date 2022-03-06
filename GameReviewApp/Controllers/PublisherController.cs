namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : Controller
{
    private readonly IMapper _mapper;
    private readonly IPublisherRepository _publisherRepository;

    public PublisherController(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    // GET
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Publisher>))]
    public IActionResult GetPublishers()
    {
        var publishers = _mapper.Map<List<PublisherDto>>(_publisherRepository.GetPublishers());

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(publishers);
    }

    // GET by Id
    [HttpGet("{publisherId}")]
    [ProducesResponseType(200, Type = typeof(Publisher))]
    [ProducesResponseType(400)]
    public IActionResult GetPublishers(int publisherId)
    {
        if (!_publisherRepository.PublisherExists(publisherId))
            return NotFound("The requested publisher does not exist!");

        var publisher = _mapper.Map<PublisherDto>(_publisherRepository.GetPublisher(publisherId));

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(publisher);
    }

    // GET game by publisher 
    [HttpGet("{publisherId}/game")]
    [ProducesResponseType(200, Type = typeof(Publisher))]
    [ProducesResponseType(400)]
    public IActionResult GetGameByPublisher(int publisherId)
    {
        if (!_publisherRepository.PublisherExists(publisherId)) return NotFound("The publisher does not exist!");

        var publisher = _mapper.Map<List<GameDto>>(
            _publisherRepository
                .GetGameByPublisher(publisherId)
        );

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(publisher);
    }
}