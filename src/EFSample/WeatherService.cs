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

        public WeatherForecast[] GetForecast()
        {
            return _context.WeatherForecast.AsNoTracking()
                .ToArray();
        }
    }
}
