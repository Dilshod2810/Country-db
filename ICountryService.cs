namespace Dapper;

public interface ICountryService
{
    List<Country> GetAll();
    Country? GetCountryById(int id);
    bool AddCountry(Country country);
    bool UpdateCountry(Country country);
    bool DeleteCountry(int id);
}