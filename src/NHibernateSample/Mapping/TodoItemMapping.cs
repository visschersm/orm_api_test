using MTech.Domain;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MTech.NHibernateSample.Mapping
{
    public class TodoItemMapping : ClassMapping<TodoItem>
    {
        public TodoItemMapping()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
            });

            Property(x => x.Title, x =>
            {
                x.Column(y => y.SqlType("varchar(128)"));
                x.NotNullable(true);
            });

            Table("TodoItem");
        }
    }
}
