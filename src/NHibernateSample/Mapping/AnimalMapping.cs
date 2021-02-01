using MTech.Domain;
using MTech.Domain.Enums;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace MTech.NHibernateSample.Mapping
{
    public class AnimalMapping : ClassMapping<Animal>
    {
        public AnimalMapping()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
            });

            Property(x => x.Name, x =>
            {
                x.Column(y => y.SqlType("nvarchar(64)"));
            });

            Property(x => x.Type, x =>
            {
                x.Column("Type");
                x.Type<EnumType<AnimalType>>();
            });
        }
    }

    public class DogMapping : ClassMapping<Dog>
    {
        public DogMapping()
        {
            Id(x => x.Id);
        }
    }

    public class CowMapping : ClassMapping<Cow>
    {
        public CowMapping()
        {
            Id(x => x.Id);
        }
    }
}
