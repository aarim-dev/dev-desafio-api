using AarimChallenge.API.Extensions;
using AarimChallenge.API.Services.Concretes;
using AarimChallenge.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddRickAndMortyHttpClient(builder.Configuration);

builder.Services.AddScoped<ICharactersService, CharactersService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
