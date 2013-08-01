using System;
using System.Collections.Generic;
using System.Linq;
using PoorsManDDD.Data.Entities;
using PoorsManDDD.Domain.Entities;
using PoorsManDDD.Domain.Repositories;
using PoorsManDDD.Domain.Specifications;

namespace PoorsManDDD.Data.Repositories
{
    internal class TodoRepository : ITodoRepository
    {
        public IEnumerable<ITodoItem> GetTodoItems()
        {
            using (var context = new TodoItemContext())
            {
                return context.TodoItems.ToList();
            }
        }

        public IEnumerable<ITodoItem> GetTodoItems(ISpecification specification)
        {
            if (!(specification is ISpecification<TodoItem>))
            {
                throw new ArgumentException("The specification is not a TodoItem specification", "specification");
            }

            var s = (ISpecification<TodoItem>) specification;
            using (var context = new TodoItemContext())
            {
                
                return context.TodoItems.Where(s.Filter).ToList();
            }
        }

        public void Add(ITodoItem item)
        {
            using (var context = new TodoItemContext())
            {
                context.TodoItems.Add((TodoItem)item);
                context.SaveChanges();
            }
        }

        public void UpdateState(Guid id, TodoState state)
        {
            using (var context = new TodoItemContext())
            {
                var item = context.TodoItems.FirstOrDefault(i => i.Id == id);
                if (item == null)
                {
                    throw new ArgumentException("Todo Item not found", "id");
                }

                item.LastModificationDate = DateTime.Now;
                item.State = state;
                context.SaveChanges();
            }
        }
    }
}
