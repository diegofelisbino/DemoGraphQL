using AutoMapper;
using CountriesAPI.Contracts;
using CountriesAPI.Interfaces;
using CountriesAPI.Models;
using Newtonsoft.Json;
using Country = CountriesAPI.Models.Country;

namespace CountriesAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryGraphqlClient _graphqlClient;
        private readonly ICountryHttpClient _httpClient;
        
        private readonly IMapper _mapper;

        public CountryService(ICountryGraphqlClient graphqlClient, ICountryHttpClient httpClient, IMapper mapper)
        {
            _graphqlClient = graphqlClient; 
            _httpClient = httpClient;            
            _mapper = mapper;
        }        

        public async Task<List<Country>> GetCountriesByContinentByGraphqlClient(string codigoContinente)
        {
            var result = await _graphqlClient.SendQueryCountries(codigoContinente);
            return _mapper.Map<List<Country>>(result.Continent.Countries);
        }

        public async Task<List<Country>> GetCountriesByContinentByHttpClient(string codigoContinente)
        {
            var result = await _httpClient.SendQueryCountries(codigoContinente);            

            return _mapper.Map<List<Country>>(result.Data.Continent.Countries);
        }
       
    }
}
