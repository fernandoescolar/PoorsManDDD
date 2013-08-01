using System;
using System.Linq.Expressions;
using PoorsManDDD.Data.Entities;
using PoorsManDDD.Domain.Entities;
using PoorsManDDD.Domain.Specifications;

namespace PoorsManDDD.Data.Specifications
{
    internal class PendingItemsSpecification : ISpecification<TodoItem>
    {
        public SpecificationType Type { get; private set; }

        public Expression<Func<TodoItem, bool>> Filter { get; private set; }

        public PendingItemsSpecification()
        {
            this.Type = SpecificationType.Finished;
            this.Filter = i => i.State == TodoState.NotStarted || i.State == TodoState.InProgress;
        }
    }
}
