using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace TestApi.IntegrationTests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<TestApi.Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UnitTest1(WebApplicationFactory<Startup> factory)
            => _factory = factory;

        [Theory]
        [InlineData("Dapper", "/swagger", "text/html")]
        [InlineData("Dapper", "/WeatherForecast", "application/json")]
        [InlineData("Dapper", "/Todo", "application/json")]
        [InlineData("Dapper", "/Animal", "application/json")]
        [InlineData("Dapper", "/Animal/dogs", "application/json")]
        [InlineData("EFCore", "/swagger", "text/html")]
        [InlineData("EFCore", "/WeatherForecast", "application/json")]
        [InlineData("EFCore", "/Todo", "application/json")]
        [InlineData("EFCore", "/Animal", "application/json")]
        [InlineData("EFCore", "/Animal/dogs", "application/json")]
        [InlineData("Linq2Db", "/swagger", "text/html")]
        [InlineData("Linq2Db", "/WeatherForecast", "application/json")]
        [InlineData("Linq2Db", "/Todo", "application/json")]
        [InlineData("Linq2Db", "/Animal", "application/json")]
        [InlineData("Linq2Db", "/Animal/dogs", "application/json")]
        [InlineData("LLBLGen", "/swagger", "text/html")]
        [InlineData("LLBLGen", "/WeatherForecast", "application/json")]
        [InlineData("LLBLGen", "/Todo", "application/json")]
        [InlineData("LLBLGen", "/Animal", "application/json")]
        [InlineData("LLBLGen", "/Animal/dogs", "application/json")]
        [InlineData("NHibernate", "/swagger", "text/html")]
        [InlineData("NHibernate", "/WeatherForecast", "application/json")]
        [InlineData("NHibernate", "/Todo", "application/json")]
        [InlineData("NHibernate", "/Animal", "application/json")]
        [InlineData("NHibernate", "/Animal/dogs", "application/json")]
        //[InlineData("/Animal/cows")]
        public async Task VerifyEndpoints_EndpointsReturnandCorrectContentType(string orm, string url, string expectedContentType)
        {
            System.Environment.SetEnvironmentVariable("ORM", orm);

            var client = _factory.CreateClient();
            client.BaseAddress = new System.Uri("https://localhost:5001");

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal($"{expectedContentType}; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }

}
