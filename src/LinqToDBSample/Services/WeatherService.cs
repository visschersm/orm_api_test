using LinqToDB;
using MTech.Domain;
using MTech.LinqToDBSample.Entities;
using System.Linq;

namespace MTech.LinqToDBSample
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherConnection _connection;

        public WeatherService(WeatherConnection connection)
            => _connection = connection;

        public void Create(WeatherForecast model)
        {
            _connection.Insert(new WeatherForecastEntity
            {
                Date = model.Date,
                Summary = model.Summary,
                TemperatureC = model.TemperatureC
            }, "WeatherForecast");
        }

        public WeatherForecast[] GetForecast()
        {
            return _connection.WeatherForecast.Select(forecast => new WeatherForecast
            {
                Date = forecast.Date,
                Summary = forecast.Summary,
                TemperatureC = forecast.TemperatureC
            }).ToArray();
        }
    }
}
