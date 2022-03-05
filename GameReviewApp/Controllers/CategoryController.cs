using GameReviewApp.DTO;

namespace GameReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    // (Using DTO)
    // GET
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public IActionResult GetCategories()
    {
        var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(categories);
    }

    // GET by Id
    [HttpGet("{Id}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetCategories(int categoryId)
    {
        if (!_categoryRepository.CategoryExists(categoryId)) return NotFound("The requested category does not exist!");

        var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(category);
    }

    [HttpGet("game/{categoryId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
    [ProducesResponseType(400)]
    public IActionResult GetGameById(int categoryId)
    {
        var games = _mapper.Map<List<Game>>(
            _categoryRepository.GetGameByCategory(categoryId)
        );

        if (!ModelState.IsValid) return BadRequest("Invalid settings");

        return Ok(games);
    }
}