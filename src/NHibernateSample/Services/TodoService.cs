using MTech.Domain;
using MTech.NHibernateSample.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace MTech.NHibernateSample
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;

        //public TodoService(ISessionFactory sessionFactory) => _sessionFactory = sessionFactory;
        public TodoService(TodoContext context)
            => _context = context;

        public void Create(TodoItem item)
        {
            _context.Save(item);
        }

        public void Delete(int id)
        {
            var entity = _context.TodoItem.Single(item => item.Id == id);
            _context.Delete(entity);
        }

        public IList<TodoItem> GetAll()
        {
            return _context.TodoItem.ToList();
        }

        public TodoItem GetById(int id)
        {
            return _context.TodoItem.SingleOrDefault(item => item.Id == id);
        }

        public void Update(int id, TodoItem model)
        {
            try
            {
                _context.BeginTransaction();

                var entity = _context.TodoItem.Single(item => item.Id == id);
                entity.Title = model.Title;

                _context.Save(entity);
                _context.Commit();
            }
            catch
            {
                _context.Rollback();
            }
            finally
            {
                _context.CloseTransaction();
            }
        }
    }
}
