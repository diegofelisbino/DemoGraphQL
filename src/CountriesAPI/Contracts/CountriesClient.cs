using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace CountriesAPI.Contracts
{
    public class CountriesClient
    {
        public async Task<ResponseCountry> GetCountriesWithHttpClient(string codigoContinente)
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
                    throw new HttpRequestException($"{response.StatusCode} - {response.Content}");
                }

                return await response.Content.ReadFromJsonAsync<ResponseCountry>();

            }
        }

        public async Task<Data> GetCountriesWithGraphQLHttpClient(string codigoContinente)
        {
            var client = new GraphQLHttpClient(BackendConstants.GRAPHQL_COUNTRIES_API_URL, new NewtonsoftJsonSerializer());

            var request = new GraphQLRequest
            {
                Query = @"query ($codigo: ID!){
                             continent(code: $codigo){
                                 countries{
                                     code,        
                                     name,
                                     capital
                                 }
                             }
                         }",
                Variables = new { codigo = codigoContinente }
            };

            var response = await client.SendQueryAsync<Data>(request);

            return response.Data;

        }

    }

}

