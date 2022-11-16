using CountriesAPI.Models;

namespace CountriesAPI.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountriesByContinentByHttpClient(string codigoContinente);
        Task<List<Country>> GetCountriesByContinentByGraphqlClient(string codigoContinente);
        
    }
}
