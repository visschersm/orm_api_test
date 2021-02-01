using Microsoft.EntityFrameworkCore;
using MTech.Domain;
using System.Linq;

namespace MTech.EFSample
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherContext _context;

        public WeatherService(WeatherContext context)
            => _context = context;

        public void Create(WeatherForecast model)
        {
            _context.WeatherForecast.Add(model);
            _context.SaveChanges();
        }

        public WeatherForecast[] GetForecast()
        {
            return _context.WeatherForecast.AsNoTracking()
                .ToArray();
        }
    }
}
