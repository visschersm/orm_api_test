using MTech.Domain;
using MTech.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MTech.NHibernateSample
{
    public class AnimalService : IAnimalService
    {
        private readonly AnimalContext _context;

        public AnimalService(AnimalContext context)
            => _context = context;

        public void Create(Animal animal)
        {
            _context.Save(animal);
        }

        public void Create(Dog dog)
        {
            _context.Save(dog);
        }

        public void Create(Cow cow)
        {
            _context.Save(cow);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Animal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Animal GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Animal> GetByType(AnimalType type)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
