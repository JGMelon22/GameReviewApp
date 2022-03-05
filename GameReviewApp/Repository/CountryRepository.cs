namespace GameReviewApp.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly DataContext _context;

    public CountryRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Country> GetCountries()
    {
        return _context.Countries.ToList();
    }

    public Country GetCountry(int id)
    {
        return _context.Countries.Where(x => x.Id == id).FirstOrDefault();
    }

    public Country GetCountryByPublisher(int publisherId)
    {
        return _context.Publishers
            .Where(x => x.Id == publisherId)
            .Select(y => y.Country)
            .FirstOrDefault();
    }

    public ICollection<Publisher> GetPublishersFromACountry(int countryId)
    {
        return _context.Publishers
            .Where(x => x.Country.Id == countryId)
            .ToList();
    }

    public bool CountryExists(int id)
    {
        return _context.Categories.Any(x => x.Id == id);
    }
}