using CountriesAPI.Interfaces;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace CountriesAPI.Contracts
{
    public class CountryGraphqlClient : ICountryGraphqlClient
    {
        public async Task<Data> SendQueryCountries(string codigoContinente)
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

