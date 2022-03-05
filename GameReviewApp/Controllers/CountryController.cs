using GameReviewApp.DTO;

namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
public class CountryController : Controller
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountryController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    // (Using DTO)
    // GET 
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    public IActionResult GetCountries()
    {
        var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(countries);
    }

    // GET by Id
    [HttpGet("{countryId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountry(int countryId)
    {
        if (!_countryRepository.CountryExists(countryId))
            return NotFound();

        var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(country);
    }

    [HttpGet("/publisher/{publishersId}")]
    [ProducesResponseType(200, Type = typeof(Game))] // Cleaner design
    [ProducesResponseType(400)]
    public IActionResult GetCountries(int publisherId)
    {
        if (!_countryRepository.CountryExists(publisherId)) return NotFound("The requested country do not exist!");

        var country = _mapper.Map<CountryDto>(
            _countryRepository.GetCountryByPublisher(publisherId)
        );

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(country);
    }
}