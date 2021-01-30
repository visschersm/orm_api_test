using LinqToDB;
using MTech.Domain;
using MTech.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MTech.LinqToDBSample
{
    public class AnimalService : IAnimalService
    {
        private readonly AnimalConnection _connection;

        public AnimalService(AnimalConnection animalConnection)
            => _connection = animalConnection;

        public void Create(Animal animal)
        {
            // TODO: Add transaction
            var animalEntity = new AnimalEntity
            {
                Type = animal.Type,
                Name = animal.Name
            };

            _connection.Insert(animalEntity, "Animal");

            /*if (animal.GetType().IsSubclassOf(typeof(Animal)))
            {
                if (animal is Dog)
                {
                    _connection.Insert(new DogEntity
                    {
                        Id = animalEntity.Id
                    });
                }
                else if (animal is Cow)
                {
                    _connection.Insert(new CowEntity
                    {
                        Id = animalEntity.Id
                    });
                }
            }*/
        }

        public void Create(Dog dog)
        {
            var animalEntity = new AnimalEntity
            {
                Type = dog.Type,
                Name = dog.Name
            };

            _connection.Insert(animalEntity, "Animal");

            var dogEntity = new DogEntity
            {
                Animal = animalEntity
            };

            _connection.Insert(dogEntity, "Dog");
        }

        public void Create(Cow cow)
        {
            var animalEntity = new AnimalEntity
            {
                Type = cow.Type,
                Name = cow.Name
            };

            _connection.Insert(animalEntity, "Animal");

            var cowEntity = new CowEntity
            {
                Id = animalEntity.Id
            };

            _connection.Insert(cowEntity, "Cow");
        }

        public void Delete(int id)
        {
            _connection.Animal
                .Where(animal => animal.Id == id)
                .Delete();
        }

        public IList<Animal> GetAll()
        {
            return _connection.Animal
                .Select(animal => new Animal
                {
                    Id = animal.Id,
                    Type = animal.Type,
                    Name = animal.Name
                })
                .ToList();
        }

        public Animal GetById(int id)
        {
            return _connection.Animal
                .Where(animal => animal.Id == id)
                .Select(animal => new Animal
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    Type = animal.Type
                })
                .SingleOrDefault();
        }

        public IList<Animal> GetByType(AnimalType type)
        {
            return _connection.Animal
                .Where(animal => animal.Type == type)
                .Select(animal => new Animal
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    Type = animal.Type
                })
                .ToList();
        }

        public void Update(int id, Animal model)
        {
            _connection.Animal
                .Where(animal => animal.Id == id)
                .Set(animal => animal.Type, model.Type)
                .Set(animal => animal.Name, model.Name)
                .Update();
        }
    }
}
