using System.Text.Json;
using UserCase1.Filters;
using UserCase1.Models;

var builder = WebApplication.CreateBuilder(args);
var countriesUrl = builder.Configuration.GetValue<string>("CountriesUrl");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/countries", async (string? name, int? population, string? sortBy, int? limit) =>
{
    using var httpClient = new HttpClient();
    var response = await httpClient.GetAsync(countriesUrl);
    response.EnsureSuccessStatusCode();

    var jsonString = await response.Content.ReadAsStringAsync();

    if (string.IsNullOrWhiteSpace(jsonString)) return Results.NotFound();

    var allCountries = JsonSerializer.Deserialize<IEnumerable<Country>>(jsonString);

    var countries = allCountries?
            .FilterByName(name)
            .FilterByPopulation(population)
            .SortByName(sortBy)
            .FilterByLimit(limit);

    return Results.Ok(countries);
});

app.Run();

public partial class Program
{ }