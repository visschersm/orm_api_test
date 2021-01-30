using Microsoft.EntityFrameworkCore;
using MTech.Domain;
using MTech.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MTech.EFSample
{
    public class AnimalService : IAnimalService
    {
        private readonly AnimalContext _context;

        public AnimalService(AnimalContext context)
            => _context = context;

        public IList<Animal> GetAll()
        {
            return _context.Animal.AsNoTracking()
                .ToList();
        }

        public Animal GetById(int id)
        {
            return _context.Animal.AsNoTracking()
                .SingleOrDefault(animal => animal.Id == id);
        }

        public IList<Animal> GetByType(AnimalType type)
        {
            return _context.Animal.AsNoTracking()
                .Where(animal => animal.Type == type)
                .ToList();
        }

        public void Create(Animal animal)
        {
            _context.Add(animal);
            _context.SaveChanges();
        }

        public void Update(int id, Animal animal)
        {
            var entity = _context.Animal.Single(animal => animal.Id == id);

            entity.Type = animal.Type;
            entity.Name = animal.Name;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Animal.Remove(new Animal { Id = id });
            _context.SaveChanges();
        }

        public void Create(Dog dog)
        {
            Create((Animal)dog);
        }

        public void Create(Cow cow)
        {
            Create((Animal)cow);
        }
    }
}
