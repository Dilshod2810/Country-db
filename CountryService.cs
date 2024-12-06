using Npgsql;
using Dapper;
// namespace Dapper;


public class CountryService:ICountryService
{
    private const string connectionString="Server=127.0.0.1;Port=5432;Database=Country_db;User Id=postgres;Password=2810;";

    public List<Country> GetAll()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
        var sql = "select * from countries";
        List<Country> countries = connection.Query<Country>(sql).ToList();
        return countries;
        }
    }

    public Country? GetCountryById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from countries where id=@id";
            Country country = connection.QuerySingle<Country>(sql, new { Id = id });
            return country;
        }
    }

    public bool AddCountry(Country country)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql =
                "insert into countries(name,capital,population,gdp,currency) values(@name,@capital,@population,@gdp,@currency)";
            var countries = connection.Execute(sql, country);
            return countries > 0;
        }
    }

    public bool UpdateCountry(Country country)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql =
                "update countries set name=@name, capital=@capital, population=@population, gdp=@gdp, currency=@currency;";
            var changed = connection.Execute(sql, country);
            return changed>0;
        }
    }

    public bool DeleteCountry(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from countries where id=@Id";
            var deleted = connection.Execute(sql, new { Id = id });
            return deleted > 0;
        }
    }
}