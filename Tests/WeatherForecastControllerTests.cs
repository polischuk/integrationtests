using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Web;
using Xunit;

namespace Tests
{
    public class WeatherForecastControllerTests : IClassFixture<BaseTestServerFixture>
    {
        private readonly BaseTestServerFixture _fixture;

        public WeatherForecastControllerTests(BaseTestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Get_ShouldReturnListResult()
        {
            // Arrange
            var response = await _fixture.Client.GetAsync("/WeatherForecast/");
            response.EnsureSuccessStatusCode();
            var models = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(await response.Content.ReadAsStringAsync());
            // Assert
            Assert.NotEmpty(models);
        }
    }
}
