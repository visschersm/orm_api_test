using MTech.Domain;
using MTech.Domain.Enums;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace MTech.NHibernateSample
{
    public class AnimalService : IAnimalService
    {
        private readonly ISession _session;

        public AnimalService(ISession session)
            => _session = session;

        public void Create(Animal animal)
        {
            _session.SaveOrUpdate(animal);
        }

        public void Create(Dog dog)
        {
            _session.SaveOrUpdate(dog);
        }

        public void Create(Cow cow)
        {
            _session.SaveOrUpdate(cow);
        }

        public void Delete(int id)
        {
            var entity = _session.Query<Animal>()
                .Single(animal => animal.Id == id);

            _session.Delete(entity);
        }

        public IList<Animal> GetAll()
        {
            return _session.Query<Animal>()
                .ToList();
        }

        public Animal GetById(int id)
        {
            return _session.Query<Animal>()
                .SingleOrDefault(animal => animal.Id == id);
        }

        public IList<Animal> GetByType(AnimalType type)
        {
            return _session.Query<Animal>()
                .Where(animal => animal.Type == type)
                .ToList();
        }

        public void Update(int id, Animal animal)
        {
            using var transaction = _session.BeginTransaction();

            try
            {
                var entity = _session.Query<Animal>()
                    .Single(animal => animal.Id == id);

                entity.Type = animal.Type;
                entity.Name = animal.Name;

                _session.SaveOrUpdate(entity);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
}
