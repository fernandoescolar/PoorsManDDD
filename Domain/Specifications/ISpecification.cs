using System;
using System.Linq.Expressions;

namespace PoorsManDDD.Domain.Specifications
{
    public interface ISpecification
    {
        SpecificationType Type { get; }
    }

    public interface ISpecification<TEntity> : ISpecification
    {
        Expression<Func<TEntity, bool>> Filter { get; }
    }
}
