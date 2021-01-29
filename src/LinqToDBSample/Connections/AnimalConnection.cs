using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace MTech.LinqToDBSample
{
    public class AnimalConnection : DataConnection
    {
        public AnimalConnection(LinqToDbConnectionOptions<AnimalConnection> options)
            : base(options)
        {

        }

        public ITable<AnimalEntity> Animal => GetTable<AnimalEntity>();
        public ITable<DogEntity> Dog => GetTable<DogEntity>();
        public ITable<CowEntity> Cow => GetTable<CowEntity>();
    }
}
