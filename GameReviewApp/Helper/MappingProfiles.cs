using GameReviewApp.DTO;

namespace GameReviewApp.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Game, GameDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Country, CountryDto>();
    }
}