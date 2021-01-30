using Dapper;
using MTech.Domain;
using MTech.Domain.Enums;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MTech.DapperSample
{
    public class AnimalService : IAnimalService
    {
        private readonly IDbConnection _connection;

        public AnimalService(IDbConnection connection)
            => _connection = connection;

        public void Create(Animal animal)
        {
            var sql = $"DECLARE @p2 int; " +
                    $"INSERT INTO [Animal] ([NAME], [Type]) VALUES('{animal.Name}', {(int)animal.Type});";

            if (animal.GetType().IsSubclassOf(typeof(Animal)))
            {
                sql += $"SELECT @p2 = [Id] FROM [Animal] WHERE [Id] = scope_identity(); " +
                    $"INSERT INTO [{animal.GetType().Name}] ([Id]) VALUES(@p2)";
            }

            _connection.Execute(sql);
        }

        public void Create(Dog dog)
        {
            var sql = $"DECLARE @p2 int; " +
                $"INSERT INTO [Animal] ([NAME], [TYPE]) VALUES('{dog.Name}', {(int)dog.Type}); " +
                $"SELECT @p2 = [Id] FROM [Animal] WHERE [Id] = scope_identity(); " +
                $"INSERT INTO [Dog] ([Id]) VALUES(@p2);";

            _connection.Execute(sql);
        }

        public void Create(Cow cow)
        {
            var sql = $"DECLARE @p2 int; " +
                $"INSERT INTO [Animal] ([NAME], [TYPE]) VALUES('{cow.Name}', {(int)cow.Type}); " +
                $"SELECT @p2 = [Id] FROM [Animal] WHERE [Id] = scope_identity(); " +
                $"INSERT INTO [Cow] ([Id]) VALUES(@p2);";

            _connection.Execute(sql);
        }

        public void Delete(int id)
        {
            var sql = $"DELETE FROM Animal WHERE id = {id}";
            _connection.Execute(sql);
        }

        public IList<Animal> GetAll()
        {
            return _connection.Query<Animal>("SELECT * from Animal")
                .ToList();
        }

        public Animal GetById(int id)
        {
            var sql = $"SELECT * FROM Animal WHERE Id = {id}";
            return _connection.Query<Animal>(sql)
                .SingleOrDefault();
        }

        public IList<Animal> GetByType(AnimalType type)
        {
            var sql = $"SELECT * FROM [Animal] WHERE Type = {(int)type}";
            return _connection.Query<Animal>(sql)
                .ToList();
        }

        public void Update(int id, Animal animal)
        {
            var sql = $"UPDATE Animal " +
                $"SET Name = '{animal.Name}', " +
                $"Type = {(int)animal.Type} " +
                $"WHERE id = {id}";

            _connection.Execute(sql);
        }
    }
}
