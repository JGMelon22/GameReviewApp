namespace GameReviewApp.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();
    Country GetCountry(int id);
    Country GetCountryByPublisher(int publisherId);
    ICollection<Publisher> GetPublishersFromACountry(int countryId);
    bool CountryExists(int id);

    // Signatures 
    bool CreateCountry(Country country);
    bool Save();
}