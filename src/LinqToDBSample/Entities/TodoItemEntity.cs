using LinqToDB.Mapping;

namespace MTech.LinqToDBSample
{
    public class TodoItemEntity
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}