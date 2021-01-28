using MTech.Domain.Enums;

namespace MTech.Domain
{
    public class Dog : Animal
    {
        public new AnimalType Type { get; set; } = AnimalType.Dog;
    }
}
