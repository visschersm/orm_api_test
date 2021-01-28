using Dapper;
using MTech.Domain;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MTech.DapperSample
{
    public class TodoService : ITodoService
    {
        private readonly IDbConnection _connection;
        public TodoService(IDbConnection connection)
            => _connection = connection;

        public IList<TodoItem> GetAll()
        {
            return _connection.Query<TodoItem>("SELECT * from TodoItem")
                .ToList();
        }

        public TodoItem GetById(int id)
        {
            return _connection.Query<TodoItem>($"SELECT * from TodoItem WHERE [Id] = {id}")
                .SingleOrDefault();
        }

        public void Create(TodoItem item)
        {
            var sql = $"INSERT INTO TodoItem (Title) VALUES('{item.Title}')";
            _connection.Execute(sql);
        }

        public void Update(int id, TodoItem item)
        {
            var sql = $"UPDATE TodoItem SET Title = '{item.Title}' WHERE id = {id}";
            _connection.Execute(sql);
        }

        public void Delete(int id)
        {
            var sql = $"DELETE FROM TodoItem WHERE id = {id}";
            _connection.Execute(sql);
        }
    }
}