using System.Data.Entity;
using PoorsManDDD.Data.Entities;

namespace PoorsManDDD.Data
{
    internal class TodoItemContext : DbContext
    {
        public TodoItemContext() : base("TodoItemConnectionString")
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
