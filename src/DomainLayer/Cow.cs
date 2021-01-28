using MTech.Domain.Enums;

namespace MTech.Domain
{
    public class Cow : Animal
    {
        public new AnimalType Type { get; set; } = AnimalType.Cow;
    }
}
