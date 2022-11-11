using System.Text.Json.Serialization;

namespace CountriesAPI.Contracts
{
    public class ResponseCountry
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public Continent Continent { get; set; }
    }

    public class Continent
    {
        public List<Country> Countries { get; set; }
    }

    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
    }
}
