using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using MTech.LinqToDBSample.Entities;

namespace MTech.LinqToDBSample
{
    public class WeatherConnection : DataConnection
    {
        public WeatherConnection(LinqToDbConnectionOptions<WeatherConnection> options)
            : base(options)
        {
        }

        public ITable<WeatherForecastEntity> WeatherForecast => GetTable<WeatherForecastEntity>().TableName("WeatherForecast");
    }
}
