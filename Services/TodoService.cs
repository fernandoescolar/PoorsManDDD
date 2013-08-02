using System;
using System.Collections.Generic;
using System.Linq;
using PoorsManDDD.Domain.Entities;
using PoorsManDDD.Domain.Repositories;
using PoorsManDDD.Domain.Specifications;
using PoorsManDDD.Services.Contracts;
using PoorsManDDD.Services.Contracts.DataTransferObjects;

namespace PoorsManDDD.Services
{
    internal class TodoService : ITodoService
    {
        private readonly ITodoRepository repository;
        private readonly IEntityFactory entityFactory;
        private readonly ISpecificationFactory specificationFactory;

        public TodoService(ITodoRepository repository, IEntityFactory entityFactory, ISpecificationFactory specificationFactory)
        {
            this.repository = repository;
            this.entityFactory = entityFactory;
            this.specificationFactory = specificationFactory;
        }

        public IEnumerable<TodoListItem> GetPending()
        {
            var specification = this.specificationFactory.GetSpecification(SpecificationType.Pending);

            return this.repository
                .GetTodoItems(specification)
                .Select(i => new TodoListItem { Id = i.Id, Name = i.Name, State = i.State.ToString()});
        }

        public void AddNew(TodoListItem item)
        {
            var entity = this.entityFactory.Create<ITodoItem>();
            entity.Id = Guid.NewGuid();
            entity.DateCreation = DateTime.Now;
            entity.LastModificationDate = DateTime.Now;
            entity.Name = item.Name;
            entity.State = TodoState.NotStarted;

            this.repository.Add(entity);
        }

        public void UpdateStateToDone(Guid itemId)
        {
            this.repository.UpdateState(itemId, TodoState.Done);
        }
    }
}
