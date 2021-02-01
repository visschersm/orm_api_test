using MTech.Domain;
using MTech.Domain.Enums;
using MTech.LLBLGen.Entities.DatabaseSpecific;
using MTech.LLBLGen.Entities.EntityClasses;
using MTech.LLBLGen.Entities.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using System.Linq;

namespace MTech.LLBLGenSample
{
    public class AnimalService : IAnimalService
    {
        public void Create(Animal animal)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("AnimalContext");
            using var adapter = new DataAccessAdapter(connectionString);
            if (animal.GetType().IsSubclassOf(typeof(Animal)))
            {
                switch (animal)
                {
                    case Dog:
                        adapter.SaveEntity(new DogEntity
                        {
                            Name = animal.Name,
                            Type = (int)animal.Type
                        });
                        break;
                    case Cow:
                        adapter.SaveEntity(new CowEntity
                        {
                            Name = animal.Name,
                            Type = (int)animal.Type
                        });
                        break;
                }
            }
            else
            {
                adapter.SaveEntity(new AnimalEntity
                {
                    Name = animal.Name,
                    Type = (int)animal.Type
                });
            }

        }

        public void Create(Dog dog)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("AnimalContext");
            using var adapter = new DataAccessAdapter(connectionString);
            adapter.SaveEntity(new DogEntity
            {
                Name = dog.Name,
                Type = (int)dog.Type
            });
        }

        public void Create(Cow cow)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("AnimalContext");
            using var adapter = new DataAccessAdapter(connectionString);
            adapter.SaveEntity(new CowEntity
            {
                Name = cow.Name,
                Type = (int)cow.Type
            });
        }

        public void Delete(int id)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("AnimalContext");
            using var adapter = new DataAccessAdapter(connectionString);
            adapter.DeleteEntity(new AnimalEntity { Id = id });
        }

        public IList<Animal> GetAll()
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("AnimalContext");
            using var adapter = new DataAccessAdapter(connectionString);
            var metaData = new LinqMetaData(adapter);
            return metaData.Animal
                .Select(animal => new Animal
                {
                    Id = animal.Id,
                    Type = (AnimalType)animal.Type,
                    Name = animal.Name
                }).ToList();
        }

        public Animal GetById(int id)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("AnimalContext");
            using var adapter = new DataAccessAdapter(connectionString);
            var metaData = new LinqMetaData(adapter);
            return metaData.Animal
                .Where(animal => animal.Id == id)
                .Select(animal => new Animal
                {
                    Id = animal.Id,
                    Type = (AnimalType)animal.Type,
                    Name = animal.Name
                }).SingleOrDefault();
        }

        public IList<Animal> GetByType(AnimalType type)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("AnimalContext");
            using var adapter = new DataAccessAdapter(connectionString);
            var metaData = new LinqMetaData(adapter);
            return metaData.Animal
                .Where(animal => animal.Type == (int)type)
                .Select(Animal => new Animal
                {
                    Id = Animal.Id,
                    Type = (AnimalType)Animal.Type,
                    Name = Animal.Name
                }).ToList();
        }

        public void Update(int id, Animal animal)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("AnimalContext");
            using var adapter = new DataAccessAdapter(connectionString);
            var entity = new AnimalEntity { Id = id };
            adapter.FetchEntity(entity);
            entity.Type = (int)animal.Type;
            entity.Name = animal.Name;
            adapter.SaveEntity(entity);
        }
    }
}
