using LinqToDB;
using MTech.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MTech.LinqToDBSample
{
    public class TodoService : ITodoService
    {
        private readonly TodoDataConnection _connection;

        public TodoService(TodoDataConnection connection)
            => _connection = connection;

        public IList<TodoItem> GetAll()
        {
            return _connection.TodoItem
                .Select(item => new TodoItem
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .ToList();
        }

        public TodoItem GetById(int id)
        {
            return _connection.TodoItem
                .Where(item => item.Id == id)
                .Select(item => new TodoItem
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .SingleOrDefault();
        }

        public void Create(TodoItem item)
        {
            _connection.Insert(new TodoItemEntity
            {
                Title = item.Title
            }, "TodoItem");
        }

        public void Update(int id, TodoItem model)
        {
            _connection.TodoItem
                .Where(item => item.Id == id)
                .Set(item => item.Title, model.Title)
                .Update();
        }

        public void Delete(int id)
        {
            _connection.TodoItem
                .Where(item => item.Id == id)
                .Delete();
        }
    }
}