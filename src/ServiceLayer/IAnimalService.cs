using MTech.Domain;
using MTech.Domain.Enums;
using System.Collections.Generic;

namespace MTech
{
    public interface IAnimalService
    {
        IList<Animal> GetAll();
        Animal GetById(int id);
        IList<Animal> GetByType(AnimalType type);
        void Create(Animal animal);
        void Create(Dog dog);
        void Create(Cow cow);
        void Update(int id, Animal animal);
        void Delete(int id);
    }
}
