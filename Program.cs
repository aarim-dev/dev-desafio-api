using dev_desafio_api.DataAccess.MongoDb;
using dev_desafio_api.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

RickAndMortyDao _rickAndMortyDao = new();
builder.Services.
AddSingleton(_rickAndMortyDao).
AddSingleton<RickAndMortyApiClient>().
AddHttpClient("RickAndMortyPublicApi", config =>
{
    config.BaseAddress = new("https://rickandmortyapi.com/api/");
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var rickAndMortyApiClient = app.Services.GetService<RickAndMortyApiClient>();

app.MapGet("/", () => "Hello World!");

app.Run();
