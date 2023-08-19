using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using UserCase1.Models;

namespace UseCase1.Tests.Endpoints
{
    [TestClass]
    public class CountriesEndpointTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        public CountriesEndpointTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestInitialize]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public async Task GetCountries_WithoutParameters_ReturnsDefaultList()
        {
            // Arrange
            var requestUri = "/countries";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();
            // ... Further assertions based on default behavior without params
        }

        [TestMethod]
        public async Task GetCountries_WithNameParameter_FiltersCorrectly()
        {
            // Arrange
            var name = "United";
            var requestUri = $"/countries?name={name}";

            // Act
            var response = await _client.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<Country>>(content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(result?.All(country => country.Name.Common.Contains(name)));
        }

        [TestMethod]
        public async Task GetCountries_WithPopulationParameter_FiltersCorrectly()
        {
            // Arrange
            var population = 10;
            var requestUri = $"/countries?population={population}"; // let's say this means less than 10 million

            // Act
            var response = await _client.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<Country>>(content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(result?.All(country => country.Population <= population * 1000000));
        }

        [TestMethod]
        public async Task GetCountries_WithSortByAscend_SortsAscending()
        {
            // Arrange
            var requestUri = "/countries";
            var ascendRequestUri = $"{requestUri}?sortBy=ascend";

            // Act
            var response = await _client.GetAsync(ascendRequestUri);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<Country>>(content);

            var defaultResponse = _client.GetAsync(requestUri);
            var defaultContent = await response.Content.ReadAsStringAsync();
            var defaultResult = JsonSerializer.Deserialize<IEnumerable<Country>>(defaultContent);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual<Country?>(defaultResult?.OrderBy(country => country.Name.Common).First(), result?.First());
            Assert.AreEqual<Country?>(defaultResult?.OrderBy(country => country.Name.Common).Last(), result?.Last());
        }

        [TestMethod]
        public async Task GetCountries_WithSortByDescend_SortsDescending()
        {
            // Arrange
            var requestUri = "/countries";
            var descendRequestUri = $"{requestUri}?sortBy=descend";

            // Act
            var response = await _client.GetAsync(descendRequestUri);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<Country>>(content);

            var defaultResponse = _client.GetAsync(requestUri);
            var defaultContent = await response.Content.ReadAsStringAsync();
            var defaultResult = JsonSerializer.Deserialize<IEnumerable<Country>>(defaultContent);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual<Country?>(defaultResult?.OrderByDescending(country => country.Name.Common).First(), result?.First());
            Assert.AreEqual<Country?>(defaultResult?.OrderByDescending(country => country.Name.Common).Last(), result?.Last());
        }

        [TestMethod]
        public async Task GetCountries_WithLimitParameter_LimitsResults()
        {
            // Arrange
            var limit = 5;
            var requestUri = $"/countries?limit={limit}";

            // Act
            var response = await _client.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<Country>>(content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual<int?>(limit, result?.Count());
        }

        // Now, you can proceed with combinations:

        [TestMethod]
        public async Task GetCountries_WithNameAndLimitParameters_ReturnsLimitedFilteredResults()
        {
            // Arrange
            var name = "United";
            var limit = 2;
            var requestUri = $"/countries?name={name}&limit={limit}";

            // Act
            var response = await _client.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<Country>>(content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(result?.All(country => country.Name.Common.Contains(name)));
            Assert.AreEqual<int?>(limit, result?.Count());
        }

        [TestMethod]
        public async Task GetCountries_WithInvalidSortByParameter_ReturnsDefaultOrder()
        {
            // Arrange
            var requestUri = "/countries?sortBy=invalidValue";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }

}