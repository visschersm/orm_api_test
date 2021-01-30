using MTech.Domain;
using NHibernate;
using System.Linq;

namespace MTech.NHibernateSample.Contexts
{
    public class TodoContext
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public TodoContext(ISession session)
            => _session = session;

        public IQueryable<TodoItem> TodoItem => _session.Query<TodoItem>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Save(TodoItem entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Delete(TodoItem entity)
        {
            _session.Delete(entity);
        }
    }
}
