using LinqToDB.Data;
using LinqToDB.Configuration;
using MTech.Domain;
using LinqToDB;

namespace MTech.LinqToDBSample
{
    public class TodoDataConnection : DataConnection
    {
        public TodoDataConnection(LinqToDbConnectionOptions<TodoDataConnection> options)
            : base(options)
        {
            
        }

        public ITable<TodoItemEntity> TodoItem => GetTable<TodoItemEntity>().TableName("TodoItem");
    }
}