namespace GameReviewApp.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Attention: with automapper, you need to map... 
        // the other way around either!
        CreateMap<Game, GameDto>();
        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherDto, Publisher>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        CreateMap<Country, CountryDto>();
        CreateMap<CountryDto, Country>();
        CreateMap<Review, ReviewDto>();
        CreateMap<Reviewer, ReviewerDto>();
    }
}