using System.Collections.Generic;
using MTech.Domain;

namespace MTech
{
    public interface ITodoService
    {
        IList<TodoItem> GetAll();
        TodoItem GetById(int id);
        void Create(TodoItem item);
        void Update(int id, TodoItem item);
        void Delete(int id);
    }
}