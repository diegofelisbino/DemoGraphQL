using AutoMapper;

namespace CountriesAPI.AutoMapper
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Contracts.Country, Models.Country>();
                
        }
    }
}
