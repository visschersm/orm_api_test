using MTech;
using MTech.Domain;
using MTech.Domain.Enums;
using System.Collections.Generic;
using MTech.Entities.DatabaseSpecific;
using MTech.Entities.EntityClasses;

namespace MTech.LLBLGenSample
{
    public class AnimalService : IAnimalService
    {
        public void Create(Animal animal)
        {
            if (animal.GetType().IsSubclassOf(typeof(Animal)))
            {

            }

            using var adapter = new DataAccessAdapter();
            // adapter.SaveEntity(new AnimalEntity
            // {
            //     Name = animal.Name,
            //     Type = animal.Type
            // });
        }

        public void Create(Dog dog)
        {
            // using var adapter = new DataAccessAdapter();
            // adapter.SaveEntity(new DogEntity
            // {
            //     Name = dog.Name,
            //     Type = dog.Type
            // });
        }

        public void Create(Cow cow)
        {
            // using var adapter = new DataAccessAdapter();
            // adapter.SaveEntity(new CowEntity
            // {
            //     Name = cow.Name,
            //     Type = cow.Type
            // });
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Animal> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Animal GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Animal> GetByType(AnimalType type)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Animal animal)
        {
            throw new System.NotImplementedException();
        }
    }
}
