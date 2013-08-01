using System;
using System.Linq.Expressions;
using PoorsManDDD.Data.Entities;
using PoorsManDDD.Domain.Specifications;

namespace PoorsManDDD.Data.Specifications
{
    internal class AllItemsSpecification : ISpecification<TodoItem>
    {
        public SpecificationType Type { get; private set; }

        public Expression<Func<TodoItem, bool>> Filter { get; private set; }

        public AllItemsSpecification()
        {
            this.Type = SpecificationType.Finished;
            this.Filter = i => true;
        }
    }
}
