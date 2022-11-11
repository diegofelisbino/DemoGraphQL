using DemoMinimalAPI.Data;
using DemoMinimalAPI.Models;
using EntityGraphQL.AspNet;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//graphql
builder.Services
    .AddGraphQLSchema<MeuDbContext>()
    .AddGraphQLServer()
    .AddQueryType<Fornecedor>();


var app = builder.Build();

app.UseHttpsRedirection();

//graphql
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL<MeuDbContext>();
});

app.MapGet("/fornecedor", async (MeuDbContext context) =>
{
    return await context.Fornecedores.ToListAsync();
})
    .WithName("GetFornecedor")
    .WithTags("Fornecedor");

app.Run();