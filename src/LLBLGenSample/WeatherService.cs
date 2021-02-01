using MTech.Domain;
using MTech.LLBLGen.Entities.DatabaseSpecific;
using MTech.LLBLGen.Entities.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Linq;

namespace MTech.LLBLGenSample
{
    public class WeatherService : IWeatherService
    {
        public void Create(WeatherForecast model)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("WeatherContext");
            using var adapter = new DataAccessAdapter(connectionString);
            var metaData = new LinqMetaData(adapter);

        }

        public WeatherForecast[] GetForecast()
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("WeatherContext");
            using var adapter = new DataAccessAdapter(connectionString);
            var metaData = new LinqMetaData(adapter);
            return metaData.WeatherForecast.Select(forecast => new WeatherForecast
            {
                Date = forecast.Date ?? DateTime.Today,
                Summary = forecast.Summary,
                TemperatureC = forecast.TemperatureC ?? 0
            }).ToArray();
        }
    }
}
