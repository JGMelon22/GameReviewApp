namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : Controller
{
    private readonly ICountryRepository _countryRepository;

    // We must provide a country, otherwise will throw an error due to SQL relationship
    private readonly IMapper _mapper;
    private readonly IPublisherRepository _publisherRepository;

    public PublisherController(IPublisherRepository publisherRepository, ICountryRepository countryRepository,
        IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _countryRepository = countryRepository;
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
    [HttpGet("game/{publisherId}")]
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

    // POST
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)] // Gets the country id from the DB 
    public IActionResult CreatePublisher([FromQuery] int countryId, [FromBody] PublisherDto publisherCreate)
    {
        if (publisherCreate == null) return BadRequest(ModelState);

        var publisher = _publisherRepository.GetPublishers()
            .Where(x => x.Name.Trim().ToUpper() == publisherCreate.Name.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (publisher != null)
        {
            ModelState.AddModelError("", "Publisher already registered!");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var publisherMap = _mapper.Map<Publisher>(publisherCreate);

        // Due publisher and country has an relationship
        publisherMap.Country = _countryRepository.GetCountry(countryId);

        if (!_publisherRepository.CreatePublisher(publisherMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok();
    }
}