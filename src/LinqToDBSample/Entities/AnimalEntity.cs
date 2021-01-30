using LinqToDB.Mapping;
using MTech.Domain.Enums;

namespace MTech.LinqToDBSample
{
    public class AnimalEntity
    {
        [PrimaryKey, Identity]
        public int Id { get; internal set; }
        public AnimalType Type { get; internal set; }
        public string Name { get; internal set; }
    }
}
