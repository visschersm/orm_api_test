using MTech.Domain.Enums;

namespace MTech.LinqToDBSample
{
    public class AnimalEntity
    {
        public int Id { get; internal set; }
        public AnimalType Type { get; internal set; }
        public string Name { get; internal set; }
    }
}
