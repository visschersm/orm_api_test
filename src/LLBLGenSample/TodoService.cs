using MTech.Domain;
using MTech.Entities.DatabaseSpecific;
using MTech.Entities.EntityClasses;
using MTech.Entities.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MTech.LLBLGenSample
{
    public class TodoService : ITodoService
    {
        public void Create(TodoItem item)
        {
            using var adapter = new DataAccessAdapter();
            adapter.SaveEntity(new TodoItemEntity
            {
                Title = item.Title
            });
        }

        public void Delete(int id)
        {
            using var adapter = new DataAccessAdapter();
            adapter.DeleteEntity(new TodoItemEntity { Id = id });
        }

        public IList<TodoItem> GetAll()
        {
            using var adapter = new DataAccessAdapter();
            var metaData = new LinqMetaData(adapter);
            return metaData.TodoItem.Select(item => new TodoItem
            {
                Id = item.Id,
                Title = item.Title
            }).ToList();
        }

        public TodoItem GetById(int id)
        {
            using var adapter = new DataAccessAdapter();
            var metaData = new LinqMetaData(adapter);
            return metaData.TodoItem.Where(item => item.Id == id)
                .Select(item => new TodoItem
                {
                    Id = item.Id,
                    Title = item.Title
                }).SingleOrDefault();
        }

        public void Update(int id, TodoItem item)
        {
            using var adapter = new DataAccessAdapter();
            var entity = new TodoItemEntity { Id = id };
            adapter.FetchEntity(entity);
            entity.Title = item.Title;
            adapter.SaveEntity(entity);
        }
    }
}
