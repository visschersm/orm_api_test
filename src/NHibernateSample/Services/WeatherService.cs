using MTech.Domain;
using NHibernate;
using System.Linq;

namespace MTech.NHibernateSample
{
    public class WeatherService : IWeatherService
    {
        private readonly ISession _session;

        public WeatherService(ISession session)
            => _session = session;

        public void Create(WeatherForecast model)
        {
            _session.SaveOrUpdate(model);
        }

        public WeatherForecast[] GetForecast()
        {
            return _session.Query<WeatherForecast>()
                .ToArray();
        }
    }
}
