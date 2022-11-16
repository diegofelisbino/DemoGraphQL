using CountriesAPI.AutoMapper;
using CountriesAPI.Contracts;
using CountriesAPI.Interfaces;
using CountriesAPI.Services;
using Country = CountriesAPI.Models.Country;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICountryHttpClient, CountryHtppClient>();
builder.Services.AddScoped<ICountryGraphqlClient, CountryGraphqlClient>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddAutoMapper(typeof(ConfigurationMapping));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/client-http/countries/{continent}", async (ICountryService service, string continent) =>
{
    try
    {
        if (string.IsNullOrEmpty(continent)) Results.BadRequest("Informe a sigla do continente");
        var result = await service.GetCountriesByContinentByHttpClient(continent);
        return Results.Ok(result);
    }    
    catch (Exception ex)
    {
        return Results.BadRequest(new { ErrorMessage = ex.Message });
    }

})
.Produces<List<Country>>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.WithName("GetCoutriesWithHttpClient")
.WithTags("HtppClient");

app.MapGet("/client-graphql/countries/{continent}", async (ICountryService service, string continent) =>
{
    try
    {
        if (string.IsNullOrEmpty(continent)) Results.BadRequest("Informe a sigla do continente");

        var coutries = await service.GetCountriesByContinentByGraphqlClient(continent);
        return Results.Ok(coutries);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { ErrorMessage = ex.Message });
    }

})
.Produces<List<Country>>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.WithName("GetCoutriesWithGraphqlClient")
.WithTags("GraphQLClient");

app.Run();

