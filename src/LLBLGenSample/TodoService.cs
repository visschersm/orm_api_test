using MTech.Domain;
using MTech.LLBLGen.Entities.DatabaseSpecific;
using MTech.LLBLGen.Entities.EntityClasses;
using MTech.LLBLGen.Entities.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
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
            var connectionString = RuntimeConfiguration.GetConnectionString("TodoContext");
            using var adapter = new DataAccessAdapter(connectionString);
            adapter.DeleteEntity(new TodoItemEntity { Id = id });
        }

        public IList<TodoItem> GetAll()
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("TodoContext");
            using var adapter = new DataAccessAdapter(connectionString);
            var metaData = new LinqMetaData(adapter);
            return metaData.TodoItem.Select(item => new TodoItem
            {
                Id = item.Id,
                Title = item.Title
            }).ToList();
        }

        public TodoItem GetById(int id)
        {
            var connectionString = RuntimeConfiguration.GetConnectionString("TodoContext");
            using var adapter = new DataAccessAdapter(connectionString);
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
            var connectionString = RuntimeConfiguration.GetConnectionString("TodoContext");
            using var adapter = new DataAccessAdapter(connectionString);
            var entity = new TodoItemEntity { Id = id };
            adapter.FetchEntity(entity);
            entity.Title = item.Title;
            adapter.SaveEntity(entity);
        }
    }
}
