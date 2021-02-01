using MTech.Domain;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MTech.NHibernateSample.Mapping
{
    public class WeatherMapping : ClassMapping<WeatherForecast>
    {
        public WeatherMapping()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
            });
        }
    }
}
