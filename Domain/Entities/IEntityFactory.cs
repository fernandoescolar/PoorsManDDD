using System;

namespace PoorsManDDD.Domain.Entities
{
    public interface IEntityFactory
    {
        TEntity Create<TEntity>() where TEntity : IEntity<Guid>;
        TEntity Create<TEntity, TKey>() where TEntity : IEntity<TKey>;
    }
}
