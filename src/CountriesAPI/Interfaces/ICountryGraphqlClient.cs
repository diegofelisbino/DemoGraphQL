using CountriesAPI.Contracts;

namespace CountriesAPI.Interfaces
{
    public interface ICountryGraphqlClient
    {
        Task<Data> SendQueryCountries(string codigoContinente);

    }
}
