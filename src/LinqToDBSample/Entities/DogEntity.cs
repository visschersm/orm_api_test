using LinqToDB.Mapping;

namespace MTech.LinqToDBSample
{
    public class DogEntity
    {
        public int Id { get; set; }

        [Association(ThisKey = nameof(DogEntity.Id), OtherKey = nameof(AnimalEntity.Id))]
        public virtual AnimalEntity Animal { get; set; }
    }
}
