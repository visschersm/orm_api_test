namespace MTech.Domain
{
    public class TodoItem
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; } = null!;
    }
}