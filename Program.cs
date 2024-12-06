using Npgsql;
using Dapper;

var connectionString = "Server=127.0.0.1;Port=5432;Database=Country_db;User Id=postgres;Password=2810;";


var countryService = new CountryService();

while (true)
{
    Console.WriteLine("=== Country Management ===");
    Console.WriteLine("1. Show All Countries");
    Console.WriteLine("2. Get Country By ID");
    Console.WriteLine("3. Add Country");
    Console.WriteLine("4. Update Country");
    Console.WriteLine("5. Delete Country");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ShowAllCountries(countryService);
            break;
        case "2":
            GetCountryById(countryService);
            break;
        case "3":
            AddCountry(countryService);
            break;
        case "4":
            
        //     UpdateCountry(countryService);
        //     break;
        // case "5":
        //     DeleteCountry(countryService);
        //     break;
        // case"6":
                
            Console.WriteLine("Exiting...");
            return;
        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}


static void ShowAllCountries(CountryService countryService)
{
    var countries = countryService.GetAll();
    Console.WriteLine("\n=== List of Countries ===");
    foreach (var country in countries)
    {
        Console.WriteLine($"ID: {country.Id}, Name: {country.Name}, Capital: {country.Capital}, Population:{country.Population}, GDP:{country.GDP}, Currency:{country.Currency}");
    }
}

static void GetCountryById(CountryService countryService)
{
    Console.Write("\nEnter Country ID: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var country = countryService.GetCountryById(id);
        if (country != null)
        {
            Console.WriteLine($"ID: {country.Id}, Name: {country.Name}, Capital: {country.Capital}, Population:{country.Population}, GDP:{country.GDP}, Currency:{country.Currency}");
        }
        else
        {
            Console.WriteLine("Country not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid ID format.");
    }
}

static void AddCountry(CountryService countryService)
{
    var country = new Country();

    Console.Write("Enter Country Name: ");
    country.Name = Console.ReadLine();

    Console.Write("Enter Capital: ");
    country.Capital = Console.ReadLine();

    Console.WriteLine("Enter Population: ");
    country.Population = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Enter GDP: ");
    country.GDP = int.Parse(Console.ReadLine());
    
    Console.Write("Enter Currency: ");
    country.Currency = Console.ReadLine();

    if (countryService.AddCountry(country))
    {
        Console.WriteLine("Country added successfully.");
    }
    else
    {
        Console.WriteLine("Failed to add country.");
    }
}