using MTech.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MTech.SQLSample
{
    public class TodoService : ITodoService
    {
        private readonly SqlConnection _connection;

        public TodoService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(TodoItem item)
        {
            var sql = "INSERT INTO [TodoItem] (Title) VALUES(@title)";
            using var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@title", item.Title);
            _connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM [TodoItem] WHERE [Id] = @id";
            using var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@id", id);
            _connection.Open();
            command.ExecuteNonQuery();
        }

        public IList<TodoItem> GetAll()
        {
            var result = new List<TodoItem>();
            var sql = "SELECT * FROM [TodoItem]";

            using (var command = new SqlCommand(sql, _connection))
            {
                _connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new TodoItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = Convert.ToString(reader["Title"])
                    });
                }
            }
            return result;
        }

        public TodoItem? GetById(int id)
        {
            TodoItem? todoItem = null;

            var sql = "SELECT * FROM [TodoItem] WHERE [Id] = @id";

            using (var command = new SqlCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (todoItem != null)
                        throw new Exception("Multiple entities found with the same id");

                    todoItem = new TodoItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = Convert.ToString(reader["Title"])
                    };
                }
            }

            return todoItem;
        }

        public void Update(int id, TodoItem item)
        {
            var sql = $"UPDATE TodoItem SET Title = @title WHERE id = @id";

            using var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@title", item.Title);

            _connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
