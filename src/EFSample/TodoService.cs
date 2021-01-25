using System;
using MTech;
using MTech.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MTech.EFSample
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
            => _context = context;

        public IList<TodoItem> GetAll()
        {
            return _context.TodoItem
                .AsNoTracking()
                .Select(item => new TodoItem
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .ToList();
        }

        public TodoItem GetById(int id)
        {
            return _context.TodoItem
                .AsNoTracking()
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
            _context.TodoItem
                .Add(new TodoItem
                {
                    Title = item.Title
                });
            _context.SaveChanges();
        }

        public void Update(int id, TodoItem item)
        {
            var entity = _context.TodoItem
                .SingleOrDefault(item => item.Id == id);

            if(entity == null) throw new ResourceNotFoundException();

            entity.Title = item.Title;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.TodoItem.Remove(new TodoItem { Id = id });
            _context.SaveChanges();
        }
    }
}
