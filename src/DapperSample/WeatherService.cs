using System;
using System.Data;
using MTech;
using MTech.Domain;
using Dapper;
using System.Collections;
using System.Linq;

namespace MTech.DapperSample
{
    public class WeatherService : IWeatherService
    {
        private readonly IDbConnection _connection;
        
        public WeatherService(IDbConnection connection)
            => _connection = connection;

        public WeatherForecast[] GetForecast()
        {
            var sql = "SELECT * FROM WeatherForecast";
            return _connection.Query<WeatherForecast>(sql).ToArray();
        }
    }
}
