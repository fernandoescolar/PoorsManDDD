using System;
using System.Linq.Expressions;
using PoorsManDDD.Data.Entities;
using PoorsManDDD.Domain.Entities;
using PoorsManDDD.Domain.Specifications;

namespace PoorsManDDD.Data.Specifications
{
    internal class FinishedItemsSpecification : ISpecification<TodoItem>
    {
        public SpecificationType Type { get; private set; }

        public Expression<Func<TodoItem, bool>> Filter { get; private set; }

        public FinishedItemsSpecification()
        {
            this.Type = SpecificationType.Finished;
            this.Filter = i => i.State == TodoState.Done || i.State == TodoState.Rejected;
        }
    }
}
