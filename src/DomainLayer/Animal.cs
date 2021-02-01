using MTech.Domain.Enums;

namespace MTech.Domain
{
    public class Animal
    {
        public virtual int Id { get; set; }
        public virtual AnimalType Type { get; set; }
        public virtual string Name { get; set; }
    }
}
