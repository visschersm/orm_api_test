using System;

namespace MTech.LinqToDBSample.Entities
{
    public class WeatherForecastEntity
    {
        public DateTime Date { get; internal set; }
        public string Summary { get; internal set; }
        public int TemperatureC { get; internal set; }
    }
}
