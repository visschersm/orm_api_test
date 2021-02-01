using System;
using MTech.Domain;

namespace MTech
{
    public interface IWeatherService
    {
        WeatherForecast[] GetForecast();
        void Create(WeatherForecast model);
    }
}
