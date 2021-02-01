using Dapper;
using MTech.Domain;
using System.Data;
using System.Linq;

namespace MTech.DapperSample
{
    public class WeatherService : IWeatherService
    {
        private readonly IDbConnection _connection;

        public WeatherService(IDbConnection connection)
            => _connection = connection;

        public void Create(WeatherForecast model)
        {
            var sql = $"INSERT INTO WeatherForecast (Date, TemperatureC, Summary) VALUES({model.Date}, {model.TemperatureC}, {model.Summary}";
            _connection.Execute(sql);
        }

        public WeatherForecast[] GetForecast()
        {
            var sql = "SELECT * FROM WeatherForecast";
            return _connection.Query<WeatherForecast>(sql).ToArray();
        }
    }
}
