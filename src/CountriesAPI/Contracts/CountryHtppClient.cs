using CountriesAPI.Interfaces;

namespace CountriesAPI.Contracts
{
    public class CountryHtppClient: ICountryHttpClient
    {
        public async Task<ResponseCountry> SendQueryCountries(string codigoContinente)
        {
            using (var client = new HttpClient())
            {
                var uri = BackendConstants.GRAPHQL_COUNTRIES_API_URL;
                
                var query = new Dictionary<string, object>();
                query.Add("query", @"query ($codigo: ID!){
                             continent(code: $codigo){
                                 countries{
                                     code,        
                                     name,
                                     capital
                                 }
                             }
                         }");
                query.Add("variables", new { codigo = codigoContinente});                

                var response = await client.PostAsJsonAsync(uri, query);
                
                if (!response.IsSuccessStatusCode)
                {                    
                    throw new HttpRequestException($"{response.StatusCode} - Ocorreu um erro");
                }

                return await response.Content.ReadFromJsonAsync<ResponseCountry>();

            }
        }
    }

}

