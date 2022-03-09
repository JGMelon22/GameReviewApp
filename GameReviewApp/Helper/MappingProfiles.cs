namespace GameReviewApp.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Attention: with automapper, you need to map... 
        // the other way around either!
        CreateMap<Game, GameDto>();
        CreateMap<GameDto, Game>();
        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherDto, Publisher>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        CreateMap<Country, CountryDto>();
        CreateMap<CountryDto, Country>();
        CreateMap<Review, ReviewDto>();
        CreateMap<ReviewDto, Review>();
        CreateMap<Reviewer, ReviewerDto>();
        CreateMap<ReviewerDto, Reviewer>();
    }
}