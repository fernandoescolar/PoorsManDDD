using System;
using PoorsManDDD.CrossDomain;
using PoorsManDDD.Domain.Entities;

namespace PoorsManDDD.Data.Entities
{
    internal class EntityFactory : IEntityFactory
    {
        private readonly IContainer container;

        public EntityFactory(IContainer container)
        {
            this.container = container;
        }

        public TEntity Create<TEntity>() where TEntity : IEntity<Guid>
        {
            return this.container.Get<TEntity>();
        }

        public TEntity Create<TEntity, TKey>() where TEntity : IEntity<TKey>
        {
            return this.container.Get<TEntity>();
        }
    }
}
