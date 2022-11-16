using CountriesAPI.Contracts;

namespace CountriesAPI.Interfaces
{
    public interface ICountryHttpClient
    {
        Task <ResponseCountry> SendQueryCountries(string codigoContinente);
    }
}
