using MTech.Domain;
using MTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MTech.SQLSample
{
    public class AnimalService : IAnimalService
    {
        private readonly SqlConnection _connection;

        public AnimalService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(Animal animal)
        {
            using var transaction = _connection.BeginTransaction();
            try
            {
                var sql = "INSERT into [Animal] (Type, Name) VALUES(@type, @name)";

                if (animal.GetType().IsSubclassOf(typeof(Animal)))
                {
                    sql += "SELECT @p2 = [Id] FROM [Animal] WHERE [Id] = scope_identity(); " +
                        $"INSERT into [{animal.GetType().Name}] ([Id]) VALUES(@p2)";
                }

                using var command = new SqlCommand(sql, _connection);
                command.Parameters.AddWithValue("@type", animal.Type);
                command.Parameters.AddWithValue("@name", animal.Name);
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public void Create(Dog dog)
        {
            Create((Animal)dog);
        }

        public void Create(Cow cow)
        {
            Create((Animal)cow);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM [TodoItem] WHERE [Id] = @id";
            using var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@id", id);
            _connection.Open();
            command.ExecuteNonQuery();
        }

        public IList<Animal> GetAll()
        {
            var result = new List<Animal>();
            var sql = "SELECT * FROM [Animal]";

            using (var command = new SqlCommand(sql, _connection))
            {
                _connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Animal
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Type = (AnimalType)Convert.ToInt32(reader["Type"]),
                        Name = Convert.ToString(reader["Name"])
                    });
                }
            }
            return result;
        }

        public Animal? GetById(int id)
        {
            Animal? animal = null;

            var sql = "SELECT * FROM [Animal] WHERE [Id] = @id";

            using (var command = new SqlCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (animal != null)
                        throw new Exception("Multiple entities found with the same id");

                    animal = new Animal
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Type = (AnimalType)Convert.ToInt32(reader["Type"]),
                        Name = Convert.ToString(reader["Name"])
                    };
                }
            }

            return animal;
        }

        public IList<Animal> GetByType(AnimalType type)
        {
            List<Animal> result = new List<Animal>();

            var sql = "SELECT * FROM [Animal] WHERE [Type] = @type";

            using (var command = new SqlCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@type", type);

                _connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Animal
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Type = (AnimalType)Convert.ToInt32(reader["Type"]),
                        Name = Convert.ToString(reader["Name"])
                    });
                }
            }

            return result;
        }

        public void Update(int id, Animal animal)
        {
            var sql = $"UPDATE [Animal] SET Type = @type, Name = @name WHERE id = @id";

            using var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@type", animal.Type);
            command.Parameters.AddWithValue("@name", animal.Name);
            _connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
