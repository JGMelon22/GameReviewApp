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
    [HttpGet("{categoryId}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetCategory(int categoryId)
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

    // POST
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
    {
        if (categoryCreate == null) return BadRequest(ModelState);

        // Checks if there is an actual instance  
        // If theres repetition, pop ups an user friendly error
        var category = _categoryRepository.GetCategories()
            .Where(x => x.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (category != null)
        {
            ModelState.AddModelError("", "Category already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var categoryMap = _mapper.Map<Category>(categoryCreate);

        if (!_categoryRepository.CreateCategory(categoryMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created!");
    }
}