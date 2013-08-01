using System;
using System.Collections.Generic;
using PoorsManDDD.Domain.Entities;
using PoorsManDDD.Domain.Specifications;

namespace PoorsManDDD.Domain.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<ITodoItem> GetTodoItems();
        IEnumerable<ITodoItem> GetTodoItems(ISpecification specification);

        void Add(ITodoItem item);
        void UpdateState(Guid id, TodoState state);
    }
}
